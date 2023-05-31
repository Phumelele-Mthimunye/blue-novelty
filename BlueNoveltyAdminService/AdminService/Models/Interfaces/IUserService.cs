using AdminService.Models.Dtos;
using AdminService.SharedServices;
using BlueNoveltyAdminService.Models;

namespace AdminService.Models.Interfaces
{
    public interface IUserService
    {
        GenericResponse<string> Register(UserDto user);
    }
}
