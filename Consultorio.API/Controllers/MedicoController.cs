using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly ICRUDService<MedicoOutputDTO, MedicoInputDTO> _service;
        private readonly IValidator<AtendimentoInputDTO> _validator;

        public MedicoController(ICRUDService<MedicoOutputDTO, MedicoInputDTO> service, IValidator<AtendimentoInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<List<MedicoOutputDTO>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<MedicoOutputDTO> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<MedicoOutputDTO> Criar([FromBody] MedicoInputDTO cadastrar)
        {
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id}")]
        public async Task<MedicoOutputDTO> Editar(int id, [FromBody] MedicoInputDTO editar)
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
