using Domain.Models;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedServices;
using Domain.Models.Interfaces.Services;

namespace BlueNoveltyAdminService.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly AppSettings _applicationSettings;
        private readonly ICustomerService _service;

        public CustomerController(IOptions<AppSettings> _applicationSettings, ICustomerService service) 
        {
            this._applicationSettings = _applicationSettings.Value;
            this._service = service;
        }

        [HttpPost("register")]
        public GenericResponse<string> Register([FromBody] UserDto request)
        {
            return _service.Register(request);
        }

        [HttpPost("login")]
        public GenericResponse<UserResponse> Login([FromBody] LoginDto request)
        {
            return _service.Login(request);
        }

        

        /* [HttpPost("login-with-google")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { this._applicationSettings.GoogleClientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);

            *//*var user = UserList.Where(x => x.Email == payload.Email).FirstOrDefault();

            if (user != null)
            {
                return Ok(JWTGenerator(user));
            }
            else
            {
                return BadRequest();
            }*//*
            return Ok(payload);
        }*/




    }
}
