using Microsoft.AspNetCore.Mvc;
using Projeto.WEP.Models;
using Projeto.WEP.Services.Interface;

namespace Projeto.WEP.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ISessaoService _sessaoService;

        public LoginController(ILoginService loginService, ISessaoService sessaoService)
        {
            _loginService = loginService;
            _sessaoService = sessaoService;
        }

        public async Task<ActionResult> Index()
        {
            if (await _sessaoService.BuscarSessaoUsuario() is not null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<ActionResult> Sair()
        {
            await _sessaoService.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel LoginVM)
        {
            var usuarioToken = await _loginService.Acessar(LoginVM);

            if (usuarioToken is not null)
            {
                await _sessaoService.CriarSessaoUsuario(usuarioToken);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
