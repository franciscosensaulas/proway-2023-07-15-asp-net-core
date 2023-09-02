using FluentValidation;
using LojaAPI.DependencyInjections;
using LojaAPI.Models.Produto;
using LojaAPI.Validators;
using LojaRepositorios.Database;
using LojaRepositorios.DependecyInjections;
using LojaServicos.DependencyInjections;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddServiceDependencyInjection()
    .AddRepositoryDependecyInjection(builder.Configuration)
    .AddApiAutoMapper()
    .AddLojaAutentication();

builder.Services.AddScoped<IValidator<ProdutoCreateModel>, ProdutoValidator>();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("healthz");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

using(var scopo = app.Services.CreateScope())
{
    var contexto = scopo.ServiceProvider.GetService<LojaContexto>();
    contexto?.Database.Migrate();
}

app.Run();
