using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace OrderingSystem.MappingConventions
{
    public class MyIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.HiLo("100");
            instance.Column(string.Format("{0}Id", instance.EntityType.Name));
        }
    }
}