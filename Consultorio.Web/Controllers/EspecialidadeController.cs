using Consultorio.Web.Filters;
using Consultorio.Web.Models;
using Consultorio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Specialityorio.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class EspecialidadeController : Controller
    {
        private readonly ICRUD<Speciality> _especialidadeService;

        // GET: especialidadeController
        public async Task<ActionResult<Speciality>> Index()
        {
            var especialidadesDB = await _especialidadeService.BuscarTodos();
            return View(especialidadesDB);
        }

        // GET: especialidadeController/Details/5
        public async Task<ActionResult<Speciality>> Details(int id)
        {
            var especialidadeDb = await _especialidadeService.BuscarPorId(id);
            return View(especialidadeDb);
        }

        // GET: especialidadeController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: especialidadeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Speciality especialidade)
        {
            try
            {

                var result = await _especialidadeService.Cadastrar(especialidade);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: especialidadeController/Edit/5
        public async Task<ActionResult<Speciality>> Edit(int id)
        {
            var result = await _especialidadeService.BuscarPorId(id);

            try
            {
                if (result != null)
                {
                    return View(result);
                }
            }
            catch
            {
                RedirectToAction(nameof(Index));
            }
            return View(result);
        }

        // POST: especialidadeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Speciality editar)
        {
            try
            {
                var result = await _especialidadeService.Editar(id, editar);
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

        // GET: especialidadeController/Delete/5
        public async Task<ActionResult<Speciality>> Delete(int id)
        {
            var result = await _especialidadeService.BuscarPorId(id);

            return View(result);
        }

        // POST: especialidadeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteExecutar(int id)
        {
            try
            {
                await _especialidadeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
