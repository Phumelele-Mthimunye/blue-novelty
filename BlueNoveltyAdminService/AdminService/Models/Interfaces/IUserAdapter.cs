using AdminService.Models.Dtos;
using AdminService.Models.Entities;

namespace AdminService.Models.Interfaces
{
    public interface IUserAdapter
    {
        void Register(UserDto user);
        bool EmailExists(string email);
        User GetUserByEmail(string email);
        UserResponse Login(LoginDto request);
    }
}
