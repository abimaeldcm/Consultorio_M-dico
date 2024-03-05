using Consultorio.Application.Interface;
using Consultorio.Application.Service;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly ICRUDService<AtendimentoOutputDTO, AtendimentoInputDTO> _service;

        public AtendimentoController(ICRUDService<AtendimentoOutputDTO, AtendimentoInputDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<AtendimentoOutputDTO>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<AtendimentoOutputDTO> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<AtendimentoOutputDTO> Criar([FromBody] AtendimentoInputDTO cadastrar)
        {
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id}")]
        public async Task<AtendimentoOutputDTO> Editar(int id, [FromBody] AtendimentoInputDTO editar)
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
