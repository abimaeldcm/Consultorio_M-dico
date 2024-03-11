using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ICRUDService<PacienteOutputDTO, PacienteInputDTO> _service;
        private readonly IValidator<PacienteInputDTO> _validator;

        public PacienteController(ICRUDService<PacienteOutputDTO, PacienteInputDTO> service, IValidator<PacienteInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PacienteOutputDTO>>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteOutputDTO>> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<PacienteOutputDTO>> Criar([FromBody] PacienteInputDTO cadastrar)
        {
            var result = _validator.Validate(cadastrar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PacienteOutputDTO>> Editar(int id, [FromBody] PacienteInputDTO editar)
        {
            var result = _validator.Validate(editar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Editar(id, editar);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}

