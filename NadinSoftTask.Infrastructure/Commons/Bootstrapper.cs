using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Infrastructure.DataBaseContext;

namespace NadinSoftTask.Infrastructure.Commons;

public static class Bootstrapper
{
    public static IServiceCollection ContextRegister(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DBConnection"),
            SqlOperation => SqlOperation.MigrationsAssembly("NadinSoftTask.Infrastructure")));


        service.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        service.AddScoped<IProductRepository, ProdcutRepository>();

        return service;
    }
}
