using LojaRepositorios.Database;
using LojaRepositorios.Repositorios;
using LojaServicos.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\source\repos\LojaWeb\LojaRepositorios\Database\WindowsFormsBancoDados.mdf;Integrated Security=True";

builder.Services.AddDbContext<LojaContexto>(
    options => options.UseSqlServer(connectionString));

// Adicionar as classes concretas com suas interfaces na inje��o de dependencia
builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

builder.Services.AddScoped<IClienteServico, ClienteServico>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

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
