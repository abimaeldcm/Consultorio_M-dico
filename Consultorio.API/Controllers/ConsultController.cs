using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsultController : ControllerBase
    {
        private readonly ICRUDService<ConsultOutputDTO, ConsultInputDTO> _service;
        private readonly IValidator<ConsultInputDTO> _validator;

        public ConsultController(ICRUDService<ConsultOutputDTO, ConsultInputDTO> service, IValidator<ConsultInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConsultOutputDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ConsultOutputDTO>> FindById(int id)
        {
            return Ok (await _service.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ConsultOutputDTO>> Create([FromBody] ConsultInputDTO create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Create(create));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ConsultOutputDTO>> Update(int id, [FromBody] ConsultInputDTO update)
        {

            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Update(id, update));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
