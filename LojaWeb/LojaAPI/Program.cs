using FluentValidation;
using LojaAPI.Controllers;
using LojaAPI.DependencyInjections;
using LojaAPI.Models.Produto;
using LojaAPI.Validators;
using LojaRepositorios.Database;
using LojaRepositorios.DependecyInjections;
using LojaRepositorios.Repositorios;
using LojaServicos.DependencyInjections;
using LojaServicos.Servicos;
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
    .AddApiAutoMapper();

builder.Services.AddScoped<IValidator<ProdutoCreateModel>, ProdutoValidator>();    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
