using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LojaMvc.Models;

namespace LojaMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ExemploCampos()
    {
        return View();
    }

    public IActionResult CadastroPersonagem()
    {
        return View();
    }

    public IActionResult CadastrarPersonagem(
        [FromQuery] string nome, 
        [FromQuery] int idade)
    {
        var anoHoje = DateTime.Now.Year;
        var anoNascimento = anoHoje - idade;
        var status = "";
        if (idade < 18)
        {
            status = "Menor de 18 anos";
        }
        else
        {
            status = "Maior ou igual a 18 anos";
        }

        var mensagem = $"{nome} nasceu em {anoNascimento}. Status: {status}";

        return Ok(mensagem);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
