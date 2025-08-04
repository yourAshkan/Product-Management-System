using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Domain.Users.Entities;
using ProductApp.Infrastructure.DataBaseContext;
using ProductApp.Domain.Products.Contracts;

namespace ProductApp.Infrastructure.Commons;

public static class Bootstrapper
{
    public static IServiceCollection ContextRegister(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DBConnection"),
            SqlOperation => SqlOperation.MigrationsAssembly("ProductApp.Infrastructure")));

        service.AddIdentity<User, IdentityRole<int>>(option =>
        {
            option.Password.RequireDigit = false;
            option.Password.RequiredLength = 8;
            option.Password.RequireUppercase = false;
        })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        service.AddScoped<IProductRepository, ProdcutRepository>();

        return service;
    }
}
