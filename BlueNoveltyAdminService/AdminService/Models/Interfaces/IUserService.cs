using AdminService.Models.Dtos;
using SharedServices;

namespace AdminService.Models.Interfaces
{
    public interface IUserService
    {
        GenericResponse<string> Register(UserDto user);
    }
}
