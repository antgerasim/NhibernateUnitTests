using FluentNHibernate.Mapping;
using OrderingSystem.Domain;

namespace OrderingSystem.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Component(x => x.Name);
            Map(x => x.CustomerIdentifier).Not.Nullable().Length(50);
            Component(x => x.Address);
            HasMany(x => x.Orders)
                .Access.CamelCaseField()
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}