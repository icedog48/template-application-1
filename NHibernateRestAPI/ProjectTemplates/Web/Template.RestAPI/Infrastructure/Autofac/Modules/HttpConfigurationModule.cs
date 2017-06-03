using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Web.Http.Cors;
using RestAPI.Infrastructure.Formatters;

namespace RestAPI.Infrastructure.Autofac.Modules
{
    public class HttpConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
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
            
            builder.RegisterInstance<HttpConfiguration>(config);

            builder.RegisterApiControllers(ThisAssembly);

            base.Load(builder);
        }
    }
}