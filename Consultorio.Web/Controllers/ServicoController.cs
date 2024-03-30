using Consultorio.Web.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class ServicoController : Controller
    {
        // GET: ServicoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServicoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
