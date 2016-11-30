using WebApi.Infrastructure.OAuth2.ServerProviders;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Web.Http;
using WebApi.Infrastructure.Autofac.Helpers;

namespace WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ContainerBuilderHelper.CreateAutofacContainer();

            var config = container.Resolve<HttpConfiguration>();

            // Set the dependency resolver to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.

            //Autofac middleware
            app.UseAutofacMiddleware(container);

            //Autofac Web API middleware
            app.UseAutofacWebApi(config);

            //standard Web API middleware
            app.UseWebApi(config);

            //Configure OAUTH2 authentication provider
            app.ConfigureOAuth(new AuthorizationServerProvider(), "/api/token");

            config.EnsureInitialized();
        }
    }
}