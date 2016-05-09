namespace OrderingSystem.Domain
{
    public abstract class Entity<TEntity>
    {
        public virtual int Id { get; set; }
    }
}
