using Microsoft.Extensions.DependencyInjection;
namespace NadinSoftTask.WebApi.Commons;

public static class Bootstrapper
{
    public static IServiceCollection AddWebApiService(this IServiceCollection service)
    {
        service.AddControllers();
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen();

        return service;
    }
}
