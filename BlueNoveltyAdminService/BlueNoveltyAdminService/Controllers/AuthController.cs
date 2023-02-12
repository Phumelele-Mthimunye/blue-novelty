using BlueNoveltyAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlueNoveltyAdminService.Controllers
{
    
    public class AuthController : Controller
    {
        private static List<User> UserList = new List<User>();
        private readonly AppSettings _applicationSettings;
        public AuthController(IOptions<AppSettings> _applicationSettings) 
        { 
            this._applicationSettings = _applicationSettings.Value;
        }

        [HttpPost("Login")] 
        public IActionResult Login([FromBody] Login model)
        {
            var user = UserList.Where(x => x.Username == model.UserName).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Username or Password was invalid");
            }

            var match = CheckPassword(model.Password, user);

            if (!match) 
            {
                return BadRequest("Username or Password was invalid");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.Username) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encrypterToken = tokenHandler.WriteToken(token);

            return Ok(new {token = encrypterToken, username = user.Username});
        }

        private bool CheckPassword(string password, User user)
        {
            bool result;

            using (HMACSHA512 hmac = new HMACSHA512(user.PasswordSalt))
            {
                var compute = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                result = compute.SequenceEqual(user.PasswordHash);
            }
            return result;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register model)
        {
            var user = new User { Username = model.UserName };
            if(model.ConfirmPassword == model.Password)
            {
                using (HMACSHA512 hmac = new HMACSHA512())
                {
                    user.PasswordSalt = hmac.Key;
                    user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
                }
            }
            else
            {
                return BadRequest("Passwords dont match");
            }

            UserList.Add(user);

            return Ok(user);
        }
    }
}
