namespace OrderingSystem.Domain
{
    public class Product : Entity<Product>
    {
        public Product() { }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual int ReorderLevel { get; set; }
        public virtual int UnitsOnStock { get; set; }
        public virtual bool Discontinued { get; set; }
    }
}