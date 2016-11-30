using Autofac;
using NHibernate;
using NhibernateRepositories.Helpers;
using System.Configuration;

namespace WebApi.Infrastructure.Autofac.Modules
{
    public class NhibernateSessionFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            var sessionFactory = SessionFactoryHelper.GetMsSqlServerSessionFactory(connectionString);

            builder.RegisterInstance(sessionFactory);

            builder.Register(context => context.Resolve<ISessionFactory>().OpenSession()).InstancePerRequest();

            base.Load(builder);
        }
    }
}