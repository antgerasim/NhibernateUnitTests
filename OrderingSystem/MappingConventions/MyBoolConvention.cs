using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace OrderingSystem.MappingConventions
{
    public class MyBoolConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type == typeof(bool))
                instance.CustomType("YesNo");
        }
    }
}