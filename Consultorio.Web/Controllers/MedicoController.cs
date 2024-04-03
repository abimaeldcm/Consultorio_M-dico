using Consultorio.Web.Filters;
using Consultorio.Web.Models;
using Consultorio.Web.Models.Enum;
using Consultorio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Consultorio.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class MedicoController : Controller
    {
        private readonly ICRUD<Consult> _atendimentoService;
        private readonly ICRUD<ServiceEntity> _servicoService;
        private readonly ICRUD<Doctor> _medicoService;
        private readonly ICRUD<Patient> _pacienteService;
        private readonly ICRUD<Speciality> _SpecialityService;

        public MedicoController(ICRUD<Consult> atendimentoService, ICRUD<ServiceEntity> servicoService, ICRUD<Doctor> medicoService, ICRUD<Patient> pacienteService, ICRUD<Speciality> SpecialityService)
        {
            _atendimentoService = atendimentoService;
            _servicoService = servicoService;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
            _SpecialityService = SpecialityService;
        }

        // GET: MedicoController
        public async Task<ActionResult<IEnumerable<Doctor>>> Index()
        {
            var MedicoDb = await _medicoService.BuscarTodos();

            return View(MedicoDb);
        }

        // GET: MedicoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _medicoService.BuscarPorId(id));
        }

        // GET: MedicoController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.BloodType = new SelectList(Enum.GetValues(typeof(ETBloodType)));
            ViewBag.SpecialityMedical = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "MedicalSpeciality");
            return View();
        }

        // POST: MedicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                ViewBag.SpecialityId = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "Name");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.BloodType = new SelectList(Enum.GetValues(typeof(ETBloodType)));
            ViewBag.SpecialityMedical = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "MedicalSpeciality");
            var medicoDb = await _medicoService.BuscarPorId(id);
            return View(medicoDb);
        }

        // POST: MedicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Doctor doctorEdit)
        {
            try
            {
                await _medicoService.Editar(id, doctorEdit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [PaginaUsuarioAdm]
        // GET: MedicoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _medicoService.BuscarPorId(id));
        }

        // POST: MedicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var medicoDb = await _medicoService.BuscarPorId(id);
                if (medicoDb != null)
                {
                   await _medicoService.Delete(id);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
