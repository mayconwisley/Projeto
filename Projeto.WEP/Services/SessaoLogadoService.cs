using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Projeto.WEP.Models;
using System.Text.Json;

namespace Projeto.WEP.Services;

public class SessaoLogadoService : ActionFilterAttribute
{
    public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string sessaoUsuario = context.HttpContext.Session.GetString("usuarioLogado");

        if (sessaoUsuario is null)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
        }
        else
        {
            UsuarioToken usuarioToken = JsonSerializer.Deserialize<UsuarioToken>(sessaoUsuario);
            if (usuarioToken is null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });

            }
        }

        return base.OnActionExecutionAsync(context, next);
    }
}
