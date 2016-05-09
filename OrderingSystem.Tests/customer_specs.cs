using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NUnit.Framework;
using OrderingSystem.Domain;
using OrderingSystem.Mappings;
using System.Linq;

namespace OrderingSystem.Tests
{
    [TestFixture]
    public class customer_specs
    {
        private ISessionFactory sessionFactory;

        [SetUp]
        public void SetUp()
        {
            sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                              .ConnectionString("server=.\\SQLEXPRESS;database=NhibernateUnitTests;integrated security=SSPI;")
                              .ShowSql())
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .BuildSessionFactory();
        }

        [Test]
        public void can_add_a_customer_without_orders()
        {
            var customer = GetCustomer();
            using (var session = sessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                session.Save(customer);
                tx.Commit();
            }
        }

        [Test]
        public void can_add_a_customer_with_orders()
        {
            var customer = GetCustomer();
            var order = new Order(customer: customer) {OrderDate = DateTime.Now, OrderTotal = 100};
            using (var session = sessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                session.Save(customer);
                session.Save(order);
                tx.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                var custFromDb = session.Get<Customer>(customer.Id);
                Console.WriteLine(custFromDb.Name.LastName);
                Console.WriteLine(custFromDb.Orders.Count());
            }
        }

        private Customer GetCustomer()
        {
            return new Customer
                       {
                           Name = new Name(firstName: "John", lastName: "Doe"),
                           Address = new Address(line1: "100 Suuny Way", line2: null, zipCode: "11222", city: "Evergreen", state: "TX"),
                           CustomerIdentifier = "JD001"
                       };
        }
    }
}