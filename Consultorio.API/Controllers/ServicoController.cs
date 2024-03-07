using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ICRUDService<ServicoOutputDTO, ServicoInputDTO> _service;
        private readonly IValidator<ServicoInputDTO> _validator;


        public ServicoController(ICRUDService<ServicoOutputDTO, ServicoInputDTO> service)
        {
            _service = service;
        }

        public ServicoController(ICRUDService<ServicoOutputDTO, ServicoInputDTO> service, IValidator<ServicoInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<List<ServicoOutputDTO>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<ServicoOutputDTO> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        public async Task<ServicoOutputDTO> Criar([FromBody] ServicoInputDTO cadastrar)
        {
            return await _service.Cadastrar(cadastrar);
        }

        [HttpPut("{id}")]
        public async Task<ServicoOutputDTO> Editar(int id, [FromBody] ServicoInputDTO editar)
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
