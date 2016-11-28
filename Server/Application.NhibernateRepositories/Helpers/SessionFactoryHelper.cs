using Application.NhibernateRepositories.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Application.NhibernateRepositories.Helpers
{
    public static class SessionFactoryHelper
    {
        public static ISessionFactory GetMsSqlServerSessionFactory(string connectionString)
        {
            var persistenceConfigurer = MsSqlConfiguration.MsSql2012
                                            .ConnectionString(connectionString)
                                                .AdoNetBatchSize(10);

            return GetSessionFactory(persistenceConfigurer);
        }

        public static ISessionFactory GetSessionFactory(IPersistenceConfigurer persistenceConfigurer)
        {
            return Fluently.Configure()
                            .Database(persistenceConfigurer)
                            .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(EntityMap<>).Assembly))
                            .BuildSessionFactory();
        }
    }
}
