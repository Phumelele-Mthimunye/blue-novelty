using Domain.Models.Dtos;
using Domain.Models.Entities;

namespace Domain.Models.Interfaces
{
    public interface IUserAdapter
    {
        void Register(UserDto user);
        bool EmailExists(string email);
        User GetUserByEmail(string email);
        UserResponse Login(LoginDto request);
    }
}
