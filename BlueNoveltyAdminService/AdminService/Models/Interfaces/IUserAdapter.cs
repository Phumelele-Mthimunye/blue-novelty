using AdminService.Models.Dtos;

namespace AdminService.Models.Interfaces
{
    public interface IUserAdapter
    {
        void Register(UserDto user);
    }
}
