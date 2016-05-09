using System;
using System.IO;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using OrderingSystem.Domain;

namespace OrderingSystem.Tests
{
    [TestFixture]
    public class hbm_mapping_spec
    {
        private Configuration configuration;

        [SetUp]
        public void SetUp()
        {
            configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                              .ConnectionString("server=.\\SQLEXPRESS;database=NhibernateUnitTests;integrated security=SSPI;")
                              .ShowSql())
                .Mappings(m => m.HbmMappings
                                   .AddFromAssemblyOf<Employee>()
                                   .AddFromAssemblyOf<Book>()
                )
                .BuildConfiguration();
        }

        [Test]
        public void can_create_schema_scripts()
        {
            new SchemaExport(configuration).Execute(true, false, false);
        }

        [Test]
        public void can_write_scripts_to_string()
        {
            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            new SchemaExport(configuration).Execute(true, false, false, null, writer);
            Console.WriteLine(sb);
        }
    }
}