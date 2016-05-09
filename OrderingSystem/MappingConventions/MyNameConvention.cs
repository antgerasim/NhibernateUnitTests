using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace OrderingSystem.MappingConventions
{
    public class MyNameConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Name != "Name") return;
            instance.Length(50);
            instance.Not.Nullable();
        }
    }
}