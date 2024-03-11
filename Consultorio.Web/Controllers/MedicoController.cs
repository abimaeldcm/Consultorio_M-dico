using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Web.Controllers
{
    public class MedicoController : Controller
    {
        // GET: MedicoController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: MedicoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: MedicoController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: MedicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
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

        // GET: MedicoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: MedicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
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

        // GET: MedicoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: MedicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
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
