using ProductApp.Presentations.Commons;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiService(builder.Configuration);

var app = builder.Build();

app.UseApiMiddlewares();

app.Run();
