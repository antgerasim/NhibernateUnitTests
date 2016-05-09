using System;
using System.Collections.Generic;

namespace OrderingSystem.Domain
{
    public class Order : Entity<Order>
    {
        // Note usage of IList<T> instead of List<T> because of NHibernate lazy loading
        private readonly IList<LineItem> lineItems; 
        public virtual IEnumerable<LineItem> LineItems { get { return lineItems; } }

        protected Order() { }   // for NHibernate

        public Order(Customer customer)
        {
            lineItems = new List<LineItem>();
            Customer = customer;
            OrderDate = DateTime.Now;
        }

        public virtual Customer Customer { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual decimal OrderTotal { get; set; }
        public virtual Employee Reference { get; set; }

        public virtual void AddProduct(Customer customer, Product product, int quantity)
        {
            Customer = customer;
            var line = new LineItem(this, quantity, product);
            lineItems.Add(line);
        }
    }
}