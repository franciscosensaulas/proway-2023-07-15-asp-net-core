using LojaMvc.DependecyInjections;
using LojaMvc.Middlewares;
using LojaRepositorios.Database;
using LojaRepositorios.DependecyInjections;
using LojaServicos.DependencyInjections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddLojaAutentication()
    .AddHttpContextAccessor()
    .AddMvcAutoMapper()
    .AddServiceDependencyInjection()
    .AddRepositoryDependecyInjection(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthorization()
    .UseSession()
    .UseMiddleware<AutenticacaoMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scopo = app.Services.CreateScope())
{
    var contexto = scopo.ServiceProvider.GetService<LojaContexto>();
    contexto?.Database.Migrate();
}

app.Run();
