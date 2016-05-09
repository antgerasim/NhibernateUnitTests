using FluentNHibernate.Mapping;
using OrderingSystem.Domain;

namespace OrderingSystem.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Map(x => x.OrderDate).Not.Nullable();
            Map(x => x.OrderTotal).Not.Nullable();
            References(x => x.Customer).Not.Nullable();
            HasMany(x => x.LineItems)
                .Access.CamelCaseField()
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}