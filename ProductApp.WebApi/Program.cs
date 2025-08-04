using ProductApp.WebApi.Commons;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApiService(builder.Configuration);


var app = builder.Build();

app.UseWebApiMiddlewares();

app.Run();
