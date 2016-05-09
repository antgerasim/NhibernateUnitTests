using FluentNHibernate.Mapping;
using OrderingSystem.Domain;

namespace OrderingSystem.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Map(x => x.Name).Not.Nullable().Length(50);
            Map(x => x.Description).Length(4000);
            Map(x => x.UnitPrice).Not.Nullable();
            Map(x => x.UnitsOnStock).Not.Nullable();
            Map(x => x.ReorderLevel).Not.Nullable();
            Map(x => x.Discontinued);
        }
    }
}