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
        public async Task<ActionResult<List<DoctorOutputDTO>>> BuscarTodos()
        {
            return Ok(await _service.BuscarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorOutputDTO>> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorOutputDTO>> Criar([FromBody] DoctorInputDTO cadastrar)
        {
            var result = _validator.Validate(cadastrar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DoctorOutputDTO>> Editar(int id, [FromBody] DoctorInputDTO editar)
        {
            var result = _validator.Validate(editar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Editar(id, editar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
