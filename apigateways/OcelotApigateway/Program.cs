using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddHealthChecks();
    //.AddUrlGroup(new Uri("https://localhost:7101/healthz"), "identityservice")
    //.AddUrlGroup(new Uri("https://localhost:7102/healthz"), "authservice");


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseHealthChecks("/healthz");
await app.UseOcelot();
app.Run();
