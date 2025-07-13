using Microsoft.Extensions.DependencyInjection;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Infrastructure.DataBaseContext;

namespace NadinSoftTask.Infrastructure.Bootstrappers;

public static class DependencyInjectionRegisters
{
    public static void ContextRegister()
    {
        var service = new ServiceCollection();
        service.AddSqlServer<AppDbContext>("server = . ; database = NadinSoftTask ; integraed security = true ; encrypt = false");


        service.AddScoped<IProductRepository,ProdcutRepository>();
    }
}
