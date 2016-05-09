using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace OrderingSystem.Tests
{
    public abstract class MappingSpecificationBase : SpecificationBase
    {
        protected Configuration configuration;
        private ISessionFactory sessionFactory;
        protected ISession session;

        protected override void BeforeAllTests()
        {
            ////HibernatingRhinos.Profiler.Appender.NHibernate
            //    .NHibernateProfiler.Initialize();

            configuration = Fluently.Configure()
                .Database(DefineDatabase)
                .Mappings(DefineMappings)
                .BuildConfiguration();

            CreateSchema(configuration);

            sessionFactory = configuration.BuildSessionFactory();
        }

        protected ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }

        protected override void Given()
        {
            base.Given();
            session = OpenSession();
        }

        protected abstract IPersistenceConfigurer DefineDatabase();
        protected abstract void DefineMappings(MappingConfiguration m);
        protected virtual void CreateSchema(Configuration configuration){}
    }
}