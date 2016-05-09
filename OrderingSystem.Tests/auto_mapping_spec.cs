using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using OrderingSystem.Domain;

namespace OrderingSystem.Tests
{
    [TestFixture]
    public class auto_mapping_spec
    {
        private Configuration configuration;

        [SetUp]
        public void SetUp()
        {
            var cfg = new OrderingSystemConfiguration();
            configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                              .ConnectionString("server=.\\SQLEXPRESS;database=NhibernateUnitTests;integrated security=SSPI;")
                              .ShowSql())
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Employee>(cfg)))
                .BuildConfiguration();
        }

        [Test]
        public void can_create_schema_scripts()
        {
            new SchemaExport(configuration).Execute(true, false, false);
        }
        
    }
}