using Application.NhibernateRepositories.Helpers;
using Application.WebApi.Infrastructure.Formatters;
using Application.WebApi.Infrastructure.OAuth2.ServerProviders;
using Autofac;
using Autofac.Integration.WebApi;
using NHibernate;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Application.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = CreateAutofacContainer();

            var config = CreateHttpConfiguration(container);

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.
            app.UseAutofacMiddleware(container);

            app.UseAutofacWebApi(config);

            app.ConfigureOAuth(new AuthorizationServerProvider(), "/api/token");

            app.UseWebApi(config);

            config.EnsureInitialized();
        }

        public virtual HttpConfiguration CreateHttpConfiguration(IContainer container)
        {
            var config = new HttpConfiguration();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new BrowserJsonFormatter());

            // Set the dependency resolver to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return config;
        }

        public virtual IContainer CreateAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetCallingAssembly());

            RegisterNhibernateSessionFactory(builder);

            return builder.Build();
        }

        public virtual void RegisterNhibernateSessionFactory(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            var sessionFactory = SessionFactoryHelper.GetMsSqlServerSessionFactory(connectionString);

            builder.RegisterInstance(sessionFactory);

            builder.Register(context => context.Resolve<ISessionFactory>().OpenSession()).InstancePerRequest();
        }
    }
}