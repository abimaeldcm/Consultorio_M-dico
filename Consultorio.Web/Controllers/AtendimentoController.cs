using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Consultorio.Web.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly ICRUD<Atendimento> _atendimentoService;
        private readonly ICRUD<Servico> _servicoService;
        private readonly ICRUD<Medico> _medicoService;
        private readonly ICRUD<Paciente> _pacienteService;

        public AtendimentoController(ICRUD<Atendimento> atendimentoService, ICRUD<Servico> servicoService, ICRUD<Medico> medicoService, ICRUD<Paciente> pacienteService)
        {
            _atendimentoService = atendimentoService;
            _servicoService = servicoService;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
        }

        // GET: AtendimentoController
        public async Task<ActionResult<Atendimento>> Index()
        {
            var atendimentosDB = await _atendimentoService.BuscarTodos();
            return View(atendimentosDB);
        }

        // GET: AtendimentoController/Details/5
        public async Task<ActionResult<Atendimento>> Details(int id)
        {
            var atendimentoDb = await _atendimentoService.BuscarPorId(id);
            return View(atendimentoDb);
        }

        // GET: AtendimentoController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.ServiceId = new SelectList((await _servicoService.BuscarTodos()).OrderBy(s => s.Nome), "Id", "Nome");
            ViewBag.PacienteId = new SelectList((await _pacienteService.BuscarTodos()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
            ViewBag.MedicoId = new SelectList((await _medicoService.BuscarTodos()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
            return View();
        }

        // POST: AtendimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Atendimento atendimento)
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
                ViewBag.ServiceId = new SelectList((await _servicoService.BuscarTodos()).OrderBy(s => s.Nome), "Id", "Nome");
                ViewBag.PacienteId = new SelectList((await _pacienteService.BuscarTodos()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
                ViewBag.MedicoId = new SelectList((await _medicoService.BuscarTodos()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
                return View();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: AtendimentoController/Edit/5
        public async Task<ActionResult<Atendimento>> Edit(int id)
        {
            var result = await _atendimentoService.BuscarPorId(id);

            try
            {
                if (result != null)
                {
                    ViewBag.ServiceId = new SelectList((await _servicoService.BuscarTodos()).OrderBy(s => s.Nome), "Id", "Nome");
                    ViewBag.PacienteId = new SelectList((await _pacienteService.BuscarTodos()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
                    ViewBag.MedicoId = new SelectList((await _medicoService.BuscarTodos()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
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
        public async Task<ActionResult> EditAsync(int id, Atendimento editar)
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
        public async Task<ActionResult<Atendimento>> Delete(int id)
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
            catch
            {
                return View();
            }
        }
    }
}
