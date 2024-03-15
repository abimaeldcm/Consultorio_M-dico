using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly ICRUDService<SpecialityOutputDTO, SpecialityInputDTO> _service;
        private readonly IValidator<SpecialityInputDTO> _validator;

        public EspecialidadeController(ICRUDService<SpecialityOutputDTO, SpecialityInputDTO> service, IValidator<SpecialityInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<SpecialityOutputDTO>> BuscarTodos()
        {
            return Ok(await _service.BuscarTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SpecialityOutputDTO>> BuscarPorId(int id)
        {
            return Ok(await _service.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<SpecialityOutputDTO>> Criar([FromBody] SpecialityInputDTO cadastrar)
        {
            var result = _validator.Validate(cadastrar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Cadastrar(cadastrar));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SpecialityOutputDTO>> Editar(int id, [FromBody] SpecialityInputDTO editar)
        {
            var result = _validator.Validate(editar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Editar(id, editar));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}

