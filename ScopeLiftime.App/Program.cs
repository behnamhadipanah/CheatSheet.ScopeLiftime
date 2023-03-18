using ScopeLiftime.Logic.Interfaces;
using ScopeLiftime.Logic;
using ScopeLiftime.App.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ITransientService, MyService>();
builder.Services.AddScoped<IScopedService, MyService>();
builder.Services.AddSingleton<ISingletonService, MyService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMyMiddleware();


app.MapControllers();

app.Run();
