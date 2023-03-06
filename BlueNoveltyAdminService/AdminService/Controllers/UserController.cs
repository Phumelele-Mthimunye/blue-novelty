using AdminService.Enums;
using BlueNoveltyAdminService.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlueNoveltyAdminService.Controllers
{
    
    public class UserController : Controller
    {
        private static List<User> UserList = new List<User>();
        private readonly AppSettings _applicationSettings;
        public UserController(IOptions<AppSettings> _applicationSettings) 
        { 
            this._applicationSettings = _applicationSettings.Value;
        }

        [HttpPost("Login")] 
        public IActionResult Login([FromBody] Login model)
        {
            var user = UserList.Where(x => x.Email == model.Email).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Username or Password was invalid");
            }

            var match = CheckPassword(model.Password, user);

            if (!match) 
            {
                return BadRequest("Username or Password was invalid");
            }

            return Ok(JWTGenerator(user));
        }

        public dynamic JWTGenerator(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.Email) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encrypterToken = tokenHandler.WriteToken(token);

            return new { token = encrypterToken, username = user.Email };
        }

        [HttpPost("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { this._applicationSettings.GoogleClientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);

            var user = UserList.Where(x => x.Email == payload.Email).FirstOrDefault();

            if (user != null)
            {
                return Ok(JWTGenerator(user));
            }
            else
            {
                return BadRequest();
            }
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
            var user = new User 
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserType = model.UserType, 
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
            };
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
