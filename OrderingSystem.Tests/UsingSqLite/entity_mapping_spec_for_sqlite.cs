using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using OrderingSystem.Domain;
using OrderingSystem.Mappings;

namespace OrderingSystem.Tests.UsingSqLite
{
    [TestFixture]
    public class entity_mapping_spec_for_sqlite : MappingSpecificationBase
    {
        protected override IPersistenceConfigurer DefineDatabase()
        {
            return SQLiteConfiguration.Standard
                .InMemory()
                .ShowSql();
                //.UsingFile("Schenker.db");
        }

        protected override void DefineMappings(MappingConfiguration m)
        {
            m.FluentMappings.AddFromAssemblyOf<ProductMap>();
        }

        protected override void Given()
        {
            base.Given();
            new SchemaExport(configuration).Execute(false, true, false, session.Connection, null);
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
        public void it_should_correctly_map_a_customer()
        {
            new PersistenceSpecification<Customer>(session)
                .CheckProperty(x => x.Name, new Name("John", "Doe"))
                .CheckProperty(x => x.Address, new Address("1001 Sunny Ln", "P.O. Box 123456", "11222", "Somewhere", "TX"))
                .CheckProperty(x => x.CustomerIdentifier, "C1002")
                .VerifyTheMappings();
        }
    }
}
