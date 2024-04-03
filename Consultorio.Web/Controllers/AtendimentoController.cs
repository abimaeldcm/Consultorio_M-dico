using Consultorio.Web.Filters;
using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Consultorio.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class AtendimentoController : Controller
    {
        private readonly ICRUD<Consult> _atendimentoService;
        private readonly ICRUD<ServiceEntity> _servicoService;
        private readonly ICRUD<Doctor> _medicoService;
        private readonly ICRUD<Patient> _pacienteService;

        public AtendimentoController(ICRUD<Consult> atendimentoService, ICRUD<ServiceEntity> servicoService, ICRUD<Doctor> medicoService, ICRUD<Patient> pacienteService)
        {
            _atendimentoService = atendimentoService;
            _servicoService = servicoService;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
        }

        // GET: AtendimentoController
        public async Task<ActionResult<Consult>> Index()
        {
            var atendimentosDB = await _atendimentoService.BuscarTodos();
            return View(atendimentosDB);
        }

        // GET: AtendimentoController/Details/5
        public async Task<ActionResult<Consult>> Details(int id)
        {
            var atendimentoDb = await _atendimentoService.BuscarPorId(id);
            return View(atendimentoDb);
        }

        // GET: AtendimentoController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.ServiceId = new SelectList((await _servicoService.BuscarTodos()).OrderBy(s => s.Name), "Id", "Name");
            ViewBag.PacienteId = new SelectList((await _pacienteService.BuscarTodos()).OrderBy(s => s.FullName), "Id", "FullName");
            ViewBag.MedicoId = new SelectList((await _medicoService.BuscarTodos()).OrderBy(s => s.FullName), "Id", "FullName");
            return View();
        }

        // POST: AtendimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Consult atendimento)
        {
            try
            {

                var result = await _atendimentoService.Cadastrar(atendimento);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                ViewBag.ServiceId = new SelectList((await _servicoService.BuscarTodos()).OrderBy(s => s.Name), "Id", "Name");
                ViewBag.PacienteId = new SelectList((await _pacienteService.BuscarTodos()).OrderBy(s => s.FullName), "Id", "FullName");
                ViewBag.MedicoId = new SelectList((await _medicoService.BuscarTodos()).OrderBy(s => s.FullName), "Id", "FullName");
                return View();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: AtendimentoController/Edit/5
        public async Task<ActionResult<Consult>> Edit(int id)
        {
            var result = await _atendimentoService.BuscarPorId(id);

            try
            {
                if (result != null)
                {
                    ViewBag.ServiceId = new SelectList((await _servicoService.BuscarTodos()).OrderBy(s => s.Name), "Id", "Name");
                    ViewBag.PacienteId = new SelectList((await _pacienteService.BuscarTodos()).OrderBy(s => s.FullName), "Id", "FullName");
                    ViewBag.MedicoId = new SelectList((await _medicoService.BuscarTodos()).OrderBy(s => s.FullName), "Id", "FullName");
                    return View(result);
                }
            }
            catch
            {
                RedirectToAction(nameof(Index));
            }
            return View(result);
        }

        // POST: AtendimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Consult editar)
        {
            try
            {
                var result = await _atendimentoService.Editar(id, editar);
                if (result.Equals(typeof(Erros)))
                {

                }
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                await Edit(id);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: AtendimentoController/Delete/5
        public async Task<ActionResult<Consult>> Delete(int id)
        {
            var result = await _atendimentoService.BuscarPorId(id);

            return View(result);
        }

        // POST: AtendimentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteExecutar(int id)
        {
            try
            {
                await _atendimentoService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = "Ops!! Não conseguimos realizar o Logoff! Destalhes:" + erro.Message;
                return View();
            }
        }
    }
}
