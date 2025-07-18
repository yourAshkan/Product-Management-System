using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NadinSoftTask.Infrastructure.Commons;
using System.Text;
using NadinSoftTask.Application.Commans;
namespace NadinSoftTask.WebApi.Commons;

public static class Bootstrapper
{
    public static IServiceCollection AddWebApiService(this IServiceCollection service,IConfiguration configuration)
    {
        service.ContextRegister(configuration);
        service.ApplicationRegister();
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

        service.AddControllers();
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen();

        return service;
    }
    public static WebApplication UseWebApiMiddlewares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapControllers();

        return app;
    }
}
