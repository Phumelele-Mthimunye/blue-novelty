using Domain.Models.Dtos;
using SharedServices;

namespace Domain.Models.Interfaces
{
    public interface ICustomerService
    {
        GenericResponse<string> Register(UserDto user);
        GenericResponse<UserResponse> Login(LoginDto request);

    }
}
