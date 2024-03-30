using Consultorio.Web.Helper;
using Consultorio.Web.Models;
using Consultorio.Web.Services;
using Consultorio.Web.Services.Interfaces;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Specialityorio.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICRUD<Patient>,PacienteService>();
builder.Services.AddScoped<ICRUD<Consult>, AtendimentoService>();
builder.Services.AddScoped<ICRUD<Doctor>, MedicoService>();
builder.Services.AddScoped<ICRUD<ServiceEntity>, ServiceService>();
builder.Services.AddScoped<ICRUD<Speciality>,EspecialidadeService>();
builder.Services.AddScoped<ICRUD<User>,LoginService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<ISessao,Sessao>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
