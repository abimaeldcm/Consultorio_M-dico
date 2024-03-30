using Consultorio.Application.Interface;
using Consultorio.Application.Services.Token;
using Consultorio.Domain.Entity;
using Consultorio.Domain.Entity.InputDTOs;
using Consultorio.Domain.Entity.OutputDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ICRUDService<UserOutputDTO, UserInputDTO> _service;
        private readonly ILoginService _loginService;
        private readonly IValidator<UserInputDTO> _validator;

        public UserController(ICRUDService<UserOutputDTO, UserInputDTO> service, ILoginService loginService, IValidator<UserInputDTO> validator)
        {
            _service = service;
            _loginService = loginService;
            _validator = validator;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLogged>> Login([FromBody] UserInputDTO login)
        {
            var user = await _loginService.FindLogin(login.Name, login.Password);
            if (user == null)
            {
                return NotFound("Usuario ou senha não localizado.");
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new UserLogged
            {
                User = user,
                Token = token
            };
        }    
        [HttpGet]
        public async Task<ActionResult<List<UserOutputDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserOutputDTO>> FindById(int id)
        {
            return await _service.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserOutputDTO>> Create([FromBody] UserInputDTO create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return await _service.Create(create);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserOutputDTO>> Update(int id, [FromBody] UserInputDTO update)
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
