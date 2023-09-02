using System.Text.Json;
using LojaRepositorios.Entidades;

namespace LojaMvc.Middlewares;
using Microsoft.AspNetCore.Http;

public class AutenticacaoMiddleware
{
    private readonly RequestDelegate _next;

    public AutenticacaoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var usuarioDaSessao = httpContext.Session.GetString("usuarioSessao");
        var controller = httpContext.GetRouteData().Values["controller"]?.ToString() ?? string.Empty;
        
        if (usuarioDaSessao == null && controller != "Autenticacao")
        {
            httpContext.Response.Redirect("/login");
            return;
        }

        if (usuarioDaSessao != null)
        {
            var usuario = JsonSerializer.Deserialize<Usuario>(usuarioDaSessao);
            httpContext.Items.Add("userName", usuario.Nome);
        }

        await _next(httpContext);
    }
}