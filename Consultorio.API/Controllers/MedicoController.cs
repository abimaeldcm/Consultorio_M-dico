using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly ICRUDService<DoctorOutputDTO, DoctorInputDTO> _service;
        private readonly IValidator<DoctorInputDTO> _validator;

        public MedicoController(ICRUDService<DoctorOutputDTO, DoctorInputDTO> service, IValidator<DoctorInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorOutputDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorOutputDTO>> FindById(int id)
        {
            return await _service.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorOutputDTO>> Create([FromBody] DoctorInputDTO create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Create(create);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DoctorOutputDTO>> Update(int id, [FromBody] DoctorInputDTO update)
        {
            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Update(id, update);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
