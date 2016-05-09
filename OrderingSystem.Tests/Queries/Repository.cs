using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace OrderingSystem.Tests.Queries
{
    public interface IRepository<T>
    {
        IQueryable<T> Query();
        T Get(int id);
        T Load(int id);
    }

    public class Repository<T> : IRepository<T>
    {
        private readonly ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public IQueryable<T> Query() { return session.Query<T>(); }
        public T Get(int id) { return session.Get<T>(id); }
        public T Load(int id) { return session.Load<T>(id); }
    }
}