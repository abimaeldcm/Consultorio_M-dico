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
        private readonly ICRUDService<ServiceOutputDTO, ServiceInputDTO> _service;
        private readonly IValidator<ServiceInputDTO> _validator;

        public ServicoController(ICRUDService<ServiceOutputDTO, ServiceInputDTO> service, IValidator<ServiceInputDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceOutputDTO>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceOutputDTO>> FindById(int id)
        {
            return await _service.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceOutputDTO>> Create([FromBody] ServiceInputDTO create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Create(create);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ServiceOutputDTO>> Update(int id, [FromBody] ServiceInputDTO update)
        {
            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Update(id, update);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
