using Template.Core.Repositories;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using Autofac.Integration.WebApi;
using System.Threading;
using System.Threading.Tasks;

namespace Template.RestAPI.Infrastructure.Filters
{
    public class AutofacTransactionFilter : IAutofacActionFilter
    {
        private readonly IUnitOfWork unitOfWork;  

        public AutofacTransactionFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception == null) this.unitOfWork.Commit();

            return Task.FromResult(0);
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            this.unitOfWork.BeginTransaction();

            return Task.FromResult(0);
        }
    }
}