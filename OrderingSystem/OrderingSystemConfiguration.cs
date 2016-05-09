using System;
using System.Linq;
using FluentNHibernate.Automapping;
using OrderingSystem.Domain;

namespace OrderingSystem
{
    public class OrderingSystemConfiguration 
        : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == typeof(Employee).Namespace;
        }
    
        public override bool IsComponent(Type type)
        {
            var componentTypes = new[] {typeof (Name), typeof (Address)};
    
            return componentTypes.Contains(type);
        }
    }
}