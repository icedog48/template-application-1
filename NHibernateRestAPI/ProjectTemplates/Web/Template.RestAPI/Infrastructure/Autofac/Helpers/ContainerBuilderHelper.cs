using Autofac;

namespace RestAPI.Infrastructure.Autofac.Helpers
{
    public static class ContainerBuilderHelper
    {
        public static IContainer CreateAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(ContainerBuilderHelper).Assembly);

            return builder.Build();
        }
    }
}