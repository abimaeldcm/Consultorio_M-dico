using Consultorio.Application.Email;
using Consultorio.Infra.IoC;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<ISeedEmail, SeedEmail>();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
