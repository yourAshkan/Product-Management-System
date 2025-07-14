using NadinSoftTask.Infrastructure.Bootstrappers;
using NadinSoftTask.WebApi.Commons;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ContextRegister(builder.Configuration);
builder.Services.AddWebApiService();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
