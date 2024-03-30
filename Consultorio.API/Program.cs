using Consultorio.Infra.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors();
        builder.Services.AddControllers();

        var configuration = builder.Configuration;
        var key = Encoding.ASCII.GetBytes(configuration["Chave:Referencia"]);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(c =>
        {            

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API Clean Arch",
                Version = "v1",
                Description = "Este projeto é uma API .NET desenvolvida para gerenciar produtos em um mercado. A aplicação oferece operações CRUD (Criar, Ler, Atualizar, Excluir) para manipular os produtos no banco de dados. A arquitetura Clean Architecture é usada para garantir uma separação clara de responsabilidades, incluindo camadas de Aplicação, Domínio, Dados e IoC. O código segue princípios de Clean Code para manutenção e legibilidade.",
                Contact = new OpenApiContact
                {
                    Name = "Abimael Mendes",
                    Url = new Uri("https://github.com/abimaeldcm"),
                    Email = "abimaelmens@hotmail.com",
                },
                License = new OpenApiLicense
                {
                    Name = "Linkedin",
                    Url = new Uri("https://www.linkedin.com/in/abimaelmends/")
                }
            }
            );
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Insira o token JWT da solicitação no campo",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            };

            c.AddSecurityDefinition("Bearer", securityScheme);

            var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] {}
                    }
                };

            c.AddSecurityRequirement(securityRequirement);
        });
    

    var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(x =>
                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}