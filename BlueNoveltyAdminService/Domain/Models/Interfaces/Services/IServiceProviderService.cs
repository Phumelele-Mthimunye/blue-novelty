using Domain.Models.Dtos;
using Domain.Models.Entities;
using SharedServices;

namespace Domain.Models.Interfaces.Services
{
    public interface IServiceProviderService
    {
        GenericResponse<string> Register(UserDto user);
        GenericResponse<UserResponse> Login(LoginDto request);
    }
}
