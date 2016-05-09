using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace OrderingSystem.MappingConventions
{
    public class MyForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            // property == null for many-to-many, one-to-many, join 
            // property != null for many-to-one
            var refName = property == null ? type.Name : property.Name;

            return string.Format("{0}Id", refName);
        }
    }
}