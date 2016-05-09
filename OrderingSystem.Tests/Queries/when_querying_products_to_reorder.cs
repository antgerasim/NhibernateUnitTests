using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OrderingSystem.Domain;

namespace OrderingSystem.Tests.Queries
{
    public class when_querying_products_to_reorder : SpecificationBase
    {
        private IRepository<Product> repository;
        private IEnumerable<Product> result;
        private GetAllProductsToOrderQueryHandler sut;

        protected override void Given()
        {
            repository = new StubbedRepository();
            sut = new GetAllProductsToOrderQueryHandler(repository);
        }

        protected override void When()
        {
            result = sut.Execute();
        }

        [Then]
        public void it_should_only_return_active_products()
        {
            Assert.That(result.Any(p => p.Discontinued), Is.False);
        }

        [Then]
        public void it_should_only_return_products_to_reorder()
        {
            Assert.That(result.All(p => p.ReorderLevel > p.UnitsOnStock), Is.True);
        }

        [Then]
        public void it_should_return_an_ordered_list()
        {
            Assert.That(result.First().Name, Is.EqualTo("Apple"));
            Assert.That(result.Last().Name, Is.EqualTo("Orange"));
        }
    }
}