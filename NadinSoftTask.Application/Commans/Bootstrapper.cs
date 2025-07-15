using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NadinSoftTask.Application.Commans
{
    public static class Bootstrapper
    {
        public static IServiceCollection ApplicationRegister(this IServiceCollection services)
        {
            services.AddMediatR(x=>x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
