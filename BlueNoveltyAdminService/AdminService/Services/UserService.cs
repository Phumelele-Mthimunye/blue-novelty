using AdminService.Enums;
using AdminService.Models.Dtos;
using AdminService.Models.Entities;
using AdminService.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedServices;
using SharedServices.Enums;
using System.Security.Cryptography;
using System.Text;

namespace AdminService.Services
{
    public class UserService: IUserService
    {
        private IUserAdapter _adapter;

        public UserService(IUserAdapter adapter)
        {
            _adapter = adapter;
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
                        new GenericError(this.GetDataMemberFieldName(nameof(request.Email)), ErrorCodeEnum.Custom.GetDescription(), "ERROR. INVALID EMAIL")
                    };
                    return new GenericResponse<UserResponse>(errors);
                }

                var match = CheckPassword(request.Password, user);

                if(!match)
                {
                    var errors = new List<GenericError>
                    {
                        new GenericError(this.GetDataMemberFieldName(nameof(request.Email)), ErrorCodeEnum.Custom.GetDescription(), "ERROR. INVALID PASSWORD")
                    };
                    return new GenericResponse<UserResponse>(errors);
                }
                var response = _adapter.Login(request);
                return new GenericResponse<UserResponse>(response);
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
                return new GenericResponse<string>(MessageOutcome.Success);
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
    }
}
