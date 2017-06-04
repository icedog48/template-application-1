using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Web.Http.Cors;
using Template.RestAPI.Infrastructure.Formatters;
using System.Linq;
using System.Web.Http.Filters;
using System.Collections.Generic;
using System.Web.Http.Controllers;
using Template.RestAPI.Infrastructure.Filters;
using Template.Core.Repositories;
using Template.Core.Models;

namespace Template.RestAPI.Infrastructure.Autofac.Modules
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

            builder.RegisterApiControllers(ThisAssembly);

            builder.RegisterInstance<HttpConfiguration>(config);

            builder.RegisterWebApiFilterProvider(config);

            base.Load(builder);
        }
    }
}