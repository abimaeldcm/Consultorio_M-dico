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
        private readonly ICRUDService<EspecialidadeOutputDTO, EspecialidadeInputDTO> _service;
        private readonly IValidator<AtendimentoInputDTO> _validator;

        public EspecialidadeController(ICRUDService<EspecialidadeOutputDTO, EspecialidadeInputDTO> service, IValidator<AtendimentoInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<List<EspecialidadeOutputDTO>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<EspecialidadeOutputDTO> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<EspecialidadeOutputDTO> Criar([FromBody] EspecialidadeInputDTO cadastrar)
        {
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id}")]
        public async Task<EspecialidadeOutputDTO> Editar(int id, [FromBody] EspecialidadeInputDTO editar)
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

