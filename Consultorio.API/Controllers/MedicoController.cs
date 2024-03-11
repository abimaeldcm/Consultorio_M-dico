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
        private readonly ICRUDService<MedicoOutputDTO, MedicoInputDTO> _service;
        private readonly IValidator<MedicoInputDTO> _validator;

        public MedicoController(ICRUDService<MedicoOutputDTO, MedicoInputDTO> service, IValidator<MedicoInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicoOutputDTO>>> BuscarTodos()
        {
            return Ok(await _service.BuscarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoOutputDTO>> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<MedicoOutputDTO>> Criar([FromBody] MedicoInputDTO cadastrar)
        {
            var result = _validator.Validate(cadastrar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MedicoOutputDTO>> Editar(int id, [FromBody] MedicoInputDTO editar)
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
