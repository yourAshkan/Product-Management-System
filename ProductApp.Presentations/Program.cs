using Microsoft.AspNetCore.Identity;
using ProductApp.Infrastructure.Identity;
using ProductApp.Presentations.Commons;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiService(builder.Configuration);

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
//    await IdentityDataSeeder.SeedRoles(roleManager);
//}

app.UseApiMiddlewares();

app.Run();
