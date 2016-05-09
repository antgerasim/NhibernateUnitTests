using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using OrderingSystem.Mappings;

namespace OrderingSystem.Tests
{
    [TestFixture]
    public class schema_spec
    {
        private Configuration configuration;

        [SetUp]
        public void SetUp()
        {
            configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                              .ConnectionString("server=.\\SQLEXPRESS;database=NhibernateUnitTests;integrated security=SSPI;")
                              .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .BuildConfiguration();
        }

        [Test]
        public void can_create_schema_scripts()
        {
            new SchemaExport(configuration).Execute(true, false, false);
        }
    }
}