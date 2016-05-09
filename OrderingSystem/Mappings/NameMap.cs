using FluentNHibernate.Mapping;
using OrderingSystem.Domain;

namespace OrderingSystem.Mappings
{
    public class NameMap : ComponentMap<Name>
    {
        public NameMap()
        {
            Map(x => x.LastName)
                .Not.Nullable()
                .Length(100);

            Map(x => x.FirstName)
                .Not.Nullable()
                .Length(100);

            Map(x => x.MiddleName)
                .Length(100);
        }
    }
}