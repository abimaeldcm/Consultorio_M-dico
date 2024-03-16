using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Web.Controllers
{
    public class PacienteController : Controller
    {

        private readonly ICRUD<Patient> _pacienteService;

        public PacienteController(ICRUD<Patient> pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // GET: PacienteController
        public async Task<ActionResult<IEnumerable<Patient>>> Index()
        {
            var Todos = await _pacienteService.BuscarTodos();
            return View(Todos);
        }

        // GET: PacienteController/Details/5
        public async Task<ActionResult<Patient>> Details(int id)
        {
            var pacienteId = await _pacienteService.BuscarPorId(id);
            return View(pacienteId);
        }

        // GET: PacienteController/Create
        public ActionResult<Patient> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Patient cadastrar)
        {
            try
            {
                await _pacienteService.Cadastrar(cadastrar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: PacienteController/Edit/5
        public async Task<ActionResult<Patient>> Edit(int id)
        {
            var pacienteId = await _pacienteService.BuscarPorId(id);
            return View(pacienteId);
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Patient editar)
        {
            try
            {
                var editarApi = await _pacienteService.Editar(id, editar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Delete/5
        public async Task<ActionResult<Patient>> Delete(int id)
        {
            var pacienteDelete = await _pacienteService.BuscarPorId(id);
            return View(pacienteDelete);
        }

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmar(int id)
        {
            try
            {
                var deletarApi = await _pacienteService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
