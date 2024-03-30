using Consultorio.Application.Interface;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutPutDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ICRUDService<EmailOutputDTO, EmailInputDTO> _service;
        private readonly IValidator<EmailInputDTO> _validator;

        public EmailController(ICRUDService<EmailOutputDTO, EmailInputDTO> service, IValidator<EmailInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmailOutputDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmailOutputDTO>> FindById(int id)
        {
            return Ok(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<EmailOutputDTO>> Create([FromBody] EmailInputDTO create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Create(create));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmailOutputDTO>> Update(int id, [FromBody] EmailInputDTO update)
        {

            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Update(id, update));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
