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
    public class ServicoController : ControllerBase
    {
        private readonly ICRUDService<ServiceOutputDTO, ServiceInputDTO> _service;
        private readonly IValidator<ServiceInputDTO> _validator;

        public ServicoController(ICRUDService<ServiceOutputDTO, ServiceInputDTO> service, IValidator<ServiceInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceOutputDTO>>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceOutputDTO>> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceOutputDTO>> Criar([FromBody] ServiceInputDTO cadastrar)
        {
            var result = _validator.Validate(cadastrar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ServiceOutputDTO>> Editar(int id, [FromBody] ServiceInputDTO editar)
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
