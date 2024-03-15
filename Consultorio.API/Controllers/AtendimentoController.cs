using Consultorio.Application.Interface;
using Consultorio.Application.Service;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly ICRUDService<ConsultOutputDTO, ConsultInputDTO> _service;
        private readonly IValidator<ConsultInputDTO> _validator;

        public AtendimentoController(ICRUDService<ConsultOutputDTO, ConsultInputDTO> service, IValidator<ConsultInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConsultOutputDTO>>> BuscarTodos()
        {
            return Ok(await _service.BuscarTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ConsultOutputDTO>> BuscarPorId(int id)
        {
            return Ok (await _service.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<ConsultOutputDTO>> Criar([FromBody] ConsultInputDTO cadastrar)
        {
            var result = _validator.Validate(cadastrar);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Cadastrar(cadastrar));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ConsultOutputDTO>> Editar(int id, [FromBody] ConsultInputDTO editar)
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
