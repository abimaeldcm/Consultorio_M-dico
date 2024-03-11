using Consultorio.Web.Models;
using Consultorio.Web.Services;
using Consultorio.Web.Services.Interfaces;
using Consultorio.Web.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICRUD<Paciente>,PacienteService>();
builder.Services.AddScoped<ICRUD<Atendimento>, AtendimentoService>();
builder.Services.AddScoped<ICRUD<Medico>, MedicoService>();
builder.Services.AddScoped<ICRUD<Servico>, ServicoServico>();

builder.Services.AddHttpClient("ConsultorioAPI", c =>
c.BaseAddress = new Uri(builder.Configuration["ServiceUri:ConsultorioAPI"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
