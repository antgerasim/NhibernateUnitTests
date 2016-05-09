using System;
using System.Linq;
using OrderingSystem.Domain;

namespace OrderingSystem.Tests.Queries
{
    public class StubbedRepository : IRepository<Product>
    {
        public IQueryable<Product> Query()
        {
            return new[]
                       {
                           new Product {Name = "Pineapple", UnitPrice = 1.55m, ReorderLevel = 10, 
                                        UnitsOnStock = 20, Discontinued = false},
                           new Product {Name = "Hazelnut", UnitPrice = 0.25m, ReorderLevel = 100, 
                                        UnitsOnStock = 20, Discontinued = true},
                           new Product {Name = "Orange", UnitPrice = 1.15m, ReorderLevel = 20, 
                                        UnitsOnStock = 10, Discontinued = false},
                           new Product {Name = "Apple", UnitPrice = 1.15m, ReorderLevel = 20, 
                                        UnitsOnStock = 15, Discontinued = false},
                       }
                .AsQueryable();
        }
    
        public Product Get(int id)
        {
            throw new NotImplementedException();
        }
    
        public Product Load(int id)
        {
            throw new NotImplementedException();
        }
    }
}