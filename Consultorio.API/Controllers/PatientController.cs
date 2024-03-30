using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ICRUDService<PatientOutputDTO, PatientInputDTO> _service;
        private readonly IValidator<PatientInputDTO> _validator;

        public PatientController(ICRUDService<PatientOutputDTO, PatientInputDTO> service, IValidator<PatientInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientOutputDTO>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientOutputDTO>> FindById(int id)
        {
            return await _service.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<PatientOutputDTO>> Create([FromBody] PatientInputDTO create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Create(create);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PatientOutputDTO>> Update(int id, [FromBody] PatientInputDTO update)
        {
            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Update(id, update);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}

