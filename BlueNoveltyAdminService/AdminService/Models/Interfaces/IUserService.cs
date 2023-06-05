using AdminService.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using SharedServices;

namespace AdminService.Models.Interfaces
{
    public interface IUserService
    {
        GenericResponse<string> Register(UserDto user);
        GenericResponse<UserResponse> Login(LoginDto request);

    }
}
