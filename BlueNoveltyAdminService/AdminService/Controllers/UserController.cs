using AdminService.Models.Dtos;
using AdminService.Models.Interfaces;
using BlueNoveltyAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedServices;

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
            /*var user = _context.User.Where(x => x.Email == model.Email).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Username or Password was invalid");
            }

            var match = CheckPassword(model.Password, user);

            if (!match)
            {
                return BadRequest("Username or Password was invalid");
            }

            return Ok(user);*/
        }

        //private dynamic JWTGenerator(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.Email) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var encrypterToken = tokenHandler.WriteToken(token);

        //    return new { token = encrypterToken, username = user.Email };
        //}

        //[HttpPost("login-with-google")]
        //public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        //{
        //    var settings = new GoogleJsonWebSignature.ValidationSettings()
        //    {
        //        Audience = new List<string> { this._applicationSettings.GoogleClientId }
        //    };

        //    var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);

        //    var user = UserList.Where(x => x.Email == payload.Email).FirstOrDefault();

        //    if (user != null)
        //    {
        //        return Ok(JWTGenerator(user));
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        


    }
}
