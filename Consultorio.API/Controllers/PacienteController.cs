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
        public async Task<List<PacienteOutputDTO>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<PacienteOutputDTO> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<PacienteOutputDTO> Criar([FromBody] PacienteInputDTO cadastrar)
        {
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id}")]
        public async Task<PacienteOutputDTO> Editar(int id, [FromBody] PacienteInputDTO editar)
        {
            return await _service.Editar(id, editar);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}

