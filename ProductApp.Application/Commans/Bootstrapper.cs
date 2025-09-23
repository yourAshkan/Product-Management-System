using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Behaviors;
using System.Reflection;

namespace ProductApp.Application.Commans
{
    public static class Bootstrapper
    {
        public static IServiceCollection ApplicationRegister(this IServiceCollection services)
        {
            services.AddMediatR(x=>x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); 

            return services;
        }
    }
}
