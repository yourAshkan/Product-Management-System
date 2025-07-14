using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Infrastructure.DataBaseContext;

namespace NadinSoftTask.Infrastructure.Bootstrappers;

public static class DependencyInjectionRegisters
{
    public static IServiceCollection ContextRegister(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddSqlServer<AppDbContext>("server = . ; database = NadinSoftTask ; integraed security = true ; encrypt = false");


        service.AddScoped<IProductRepository,ProdcutRepository>();


        return service;
    }
}
