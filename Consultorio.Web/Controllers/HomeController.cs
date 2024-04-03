using Consultorio.Web.Filters;
using Consultorio.Web.Helper;
using Consultorio.Web.Models;
using Consultorio.Web.Services;
using Consultorio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService _loginService;
        private readonly ISessao _sessao;
        private readonly ICRUD<Consult> _atendimentoService;

        public HomeController(ILogger<HomeController> logger, ILoginService loginService, ISessao sessao, ICRUD<Consult> atendimentoService)
        {
            _logger = logger;
            _loginService = loginService;
            _sessao = sessao;
            _atendimentoService = atendimentoService;
        }

        public async Task<IActionResult> Index()
        {
            var listaItens = await _atendimentoService.BuscarTodos();

            return View(listaItens);
        }
        public IActionResult Sair()
        {
            try
            {
                _sessao.RemoverSessaoUsuario();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos realizar o Logoff! Detalhes:" + erro.Message;
                return RedirectToAction("Index"); ;
            }

        }
    }
}
