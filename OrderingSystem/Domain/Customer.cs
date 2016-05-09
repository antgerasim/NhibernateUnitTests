using System.Collections.Generic;

namespace OrderingSystem.Domain
{
    public class Customer : Entity<Customer>
    {
        private readonly IList<Order> orders;
        public virtual IEnumerable<Order> Orders { get { return orders; } }

        public virtual string CustomerIdentifier { get; set; }
        public virtual Name Name { get; set; }
        public virtual Address Address { get; set; }

        public Customer()
        {
            orders = new List<Order>();
        }

        public virtual void PlaceOrder(LineInfo[] lineInfos, IDictionary<int, Product> products)
        {
            var order = new Order(this);
            foreach (var lineInfo in lineInfos)
            {
                var product = products[lineInfo.ProductId];
                order.AddProduct(this, product, lineInfo.Quantity);
            }
            orders.Add(order);
        }
    }
}
