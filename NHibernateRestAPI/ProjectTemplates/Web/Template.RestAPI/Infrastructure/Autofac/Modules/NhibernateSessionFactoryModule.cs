using Autofac;
using FluentMigrator.Runner.Processors.SqlServer;
using Migrations.Helpers;
using NHibernate;
using ORM.NHibernate.Helpers;
using System.Configuration;

namespace RestAPI.Infrastructure.Autofac.Modules
{
    public class NhibernateSessionFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            Runner.MigrateToLatest<SqlServer2014ProcessorFactory>(connectionString);

            var sessionFactory = SessionFactoryHelper.GetMsSqlServerSessionFactory(connectionString);

            builder.RegisterInstance(sessionFactory);

            builder.Register(context => context.Resolve<ISessionFactory>().OpenSession()).InstancePerRequest();

            base.Load(builder);
        }
    }
}