using Autofac;
using Autofac.Integration.WebApi;
using Template.Core.Models;
using Template.Core.Repositories;
using Template.Core.Services;
using Template.Core.Services.Default;
using Template.RestAPI.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Template.RestAPI.Infrastructure.Autofac.Modules
{
    /// <summary>
    /// Modulo para registro de filtros que dependem de recursos criados com InstancePerHttpRequest
    /// </summary>
    public class AutofacRequestFiltersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => new AutofacTransactionFilter(c.Resolve<IUnitOfWork>()))
            //           .AsWebApiActionFilterFor<EndpointsController>(actionSelector => actionSelector.Set(default(Endpoint))) // POST                       
            //       .InstancePerRequest();

            //builder.Register(c => new AutofacTransactionFilter(c.Resolve<IUnitOfWork>()))
            //           .AsWebApiActionFilterFor<EndpointsController>(actionSelector => actionSelector.Delete(default(int)))   // DELETE
            //       .InstancePerRequest();
            

            base.Load(builder);
        }
    }
}