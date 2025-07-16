using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Infrastructure.DataBaseContext;
using System.Text;

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

        service.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
            };
        });

        service.AddScoped<IProductRepository, ProdcutRepository>();

        return service;
    }
}
