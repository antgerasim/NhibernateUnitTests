using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using log4net.Config;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using OrderingSystem.Domain;
using OrderingSystem.Mappings;

namespace OrderingSystem.Tests
{
    [TestFixture]
    public class entity_mapping_spec : MappingSpecificationBase
    {
        protected override IPersistenceConfigurer DefineDatabase()
        {
            return MsSqlConfiguration.MsSql2012
                .ConnectionString("server=.\\SQLEXPRESS;" +
                                  "database=NhibernateUnitTests;" +
                                  "integrated security=SSPI;");
        }

        protected override void DefineMappings(MappingConfiguration m)
        {
            m.FluentMappings.AddFromAssemblyOf<ProductMap>();
        }

        protected override void CreateSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Execute(false, true, false);
        }

        protected override void BeforeAllTests()
        {
            base.BeforeAllTests();
            XmlConfigurator.Configure();
        }

        [Then]
        public void it_should_save_and_reload_the_product_correctly()
        {
            var product = new Product
            {
                Name = "Apple",
                Description = "",
                UnitPrice = 1.50m,
                ReorderLevel = 10,
                Discontinued = true
            };
            session.Save(product);
            session.Flush();
            session.Evict(product);

            var fromDb = session.Get<Product>(product.Id);
            Assert.That(fromDb, Is.Not.Null);
            Assert.That(fromDb.Name, Is.EqualTo(product.Name));
            Assert.That(fromDb.Description, Is.EqualTo(product.Description));
            Assert.That(fromDb.UnitPrice, Is.EqualTo(product.UnitPrice));
            Assert.That(fromDb.ReorderLevel, Is.EqualTo(product.ReorderLevel));
            Assert.That(fromDb.Discontinued, Is.EqualTo(product.Discontinued));
        }

        [Then]
        public void it_should_correctly_map_a_product()
        {
            new PersistenceSpecification<Product>(session)
                .CheckProperty(x => x.Name, "Apple")
                .CheckProperty(x => x.Description, "Some description")
                .CheckProperty(x => x.UnitPrice, 1.50m)
                .CheckProperty(x => x.ReorderLevel, 10)
                .CheckProperty(x => x.Discontinued, true)
                .VerifyTheMappings();
        }

        [Then]
        public void it_should_correctly_map_a_employee()
        {
            new PersistenceSpecification<Employee>(session)
                .CheckProperty(x => x.Name, new Name("John", "Doe"))
                .VerifyTheMappings();
        }

        [Then]
        public void it_should_correctly_map_a_customer()
        {
            new PersistenceSpecification<Customer>(session)
                .CheckProperty(x => x.Name, new Name("John", "Doe"))
                .CheckProperty(x => x.Address,
                    new Address("1001 Sunny Ln", "P.O. Box 123456", "11222", "Somewhere", "TX"))
                .CheckProperty(x => x.CustomerIdentifier, "C1002")
                .VerifyTheMappings();
        }
    }
}