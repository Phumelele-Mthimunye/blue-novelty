using AdminService.Models.Dtos;
using AdminService.Models.Entities;
using AdminService.Models.Interfaces;
using BlueNoveltyAdminService.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedServices;
using SharedServices.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AdminService.Services
{
    public class UserService: IUserService
    {
        private IUserAdapter _adapter;
        private readonly AppSettings _applicationSettings;

        public UserService(IUserAdapter adapter, IOptions<AppSettings> appSettings)
        {
            _adapter = adapter;
            _applicationSettings = appSettings.Value;
        }

        public GenericResponse<UserResponse> Login(LoginDto request)
        {
            try
            {
                var user = _adapter.GetUserByEmail(request.Email);

                if (user == null)
                {
                    var errors = new List<GenericError>
                    {
                        new GenericError(this.GetDataMemberFieldName(nameof(request.Email)), ErrorCodeEnum.Custom.GetDescription(), "ERROR. INVALID EMAIL OR PASSWORD")
                    };
                    return new GenericResponse<UserResponse>(errors);
                }

                var match = CheckPassword(request.Password, user);

                if(!match)
                {
                    var errors = new List<GenericError>
                    {
                        new GenericError(this.GetDataMemberFieldName(nameof(request.Email)), ErrorCodeEnum.Custom.GetDescription(), "ERROR. INVALID EMAIL OR PASSWORD")
                    };
                    return new GenericResponse<UserResponse>(errors);
                }
                var response = _adapter.Login(request);
                return new GenericResponse<UserResponse>(JWTGenerator(response));
            }
            catch
            {
                return new GenericResponse<UserResponse>(MessageOutcome.Failure);
            }
        }

        public GenericResponse<string> Register(UserDto request)
        {
            try
            {
                if(_adapter.EmailExists(request.Email.ToLower()))
                {
                    var errors = new List<GenericError>
                    {
                        new GenericError(this.GetDataMemberFieldName(nameof(request.Email)), ErrorCodeEnum.Custom.GetDescription(), "ERROR. EMAIL IS ALREADY REGISTERED")
                    };
                    return new GenericResponse<string>(errors);
                }
                _adapter.Register(request);
                return new GenericResponse<string>(MessageOutcome.Success);
            }
            catch
            {
                return new GenericResponse<string>(MessageOutcome.Failure);
            }
        }

        private bool CheckPassword(string password, User user)
        {
            bool result;

            using (HMACSHA512 hmac = new HMACSHA512(user.PasswordSalt))
            {
                var compute = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                result = compute.SequenceEqual(user.PasswordHash);
            }
            return result;
        }

        private UserResponse JWTGenerator(UserResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Username) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encrypterToken = tokenHandler.WriteToken(token);

            user.Token = encrypterToken;

            return user;
        }
    }
}
