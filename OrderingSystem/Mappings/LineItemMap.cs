using FluentNHibernate.Mapping;
using OrderingSystem.Domain;

namespace OrderingSystem.Mappings
{
    public class LineItemMap : ClassMap<LineItem>
    {
        public LineItemMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");
            References(x => x.Order).Not.Nullable();
            References(x => x.Product).Not.Nullable();
            Map(x => x.Quantity).Not.Nullable();
            Map(x => x.UnitPrice).Not.Nullable();
            Map(x => x.Discount).Not.Nullable();
        }
    }
}