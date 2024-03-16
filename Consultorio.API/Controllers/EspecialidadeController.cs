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
        public async Task<ActionResult<SpecialityOutputDTO>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SpecialityOutputDTO>> FindById(int id)
        {
            return Ok(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<SpecialityOutputDTO>> Create([FromBody] SpecialityInputDTO create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Create(create));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SpecialityOutputDTO>> Update(int id, [FromBody] SpecialityInputDTO update)
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

