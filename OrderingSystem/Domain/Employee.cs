namespace OrderingSystem.Domain
{
    public class Employee : Entity<Employee>
    {
        public virtual Name Name { get; set; }
    }
}
