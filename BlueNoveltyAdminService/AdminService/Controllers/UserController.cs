using AdminService.Models.Dtos;
using AdminService.Models.Entities;
using AdminService.Models.Interfaces;
using BlueNoveltyAdminService.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlueNoveltyAdminService.Controllers
{
    [Route("admin")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppSettings _applicationSettings;
        private readonly IUserService _service;

        public UserController(IOptions<AppSettings> _applicationSettings, IUserService service) 
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
