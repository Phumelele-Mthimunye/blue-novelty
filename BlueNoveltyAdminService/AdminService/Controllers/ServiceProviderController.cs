using Domain.Models;
using Domain.Models.Dtos;
using Domain.Models.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedServices;

namespace BlueNoveltyAdminService.Controllers
{
    [Route("serviceProvider")]
    [ApiController]
    public class ServiceProviderController : Controller
    {
        private readonly AppSettings _applicationSettings;
        private readonly IServiceProviderService _service;

        public ServiceProviderController(IOptions<AppSettings> _applicationSettings, IServiceProviderService service) 
        {
            this._service = service;
            this._applicationSettings = _applicationSettings.Value;
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
