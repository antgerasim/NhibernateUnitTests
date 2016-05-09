using System.Collections.Generic;
using System.Linq;
using OrderingSystem.Domain;

namespace OrderingSystem.Tests.Queries
{
    public class GetAllProductsToOrderQueryHandler
    {
        private readonly IRepository<Product> repository;

        public GetAllProductsToOrderQueryHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Product> Execute()
        {
            return repository.Query()
                .Where(p => !p.Discontinued && p.UnitsOnStock < p.ReorderLevel)
                .OrderBy(p => p.Name)
                .ToArray();
        }
    }
}