using Domain.Models.Dtos;
using Domain.Models.Entities;

namespace Domain.Models.Interfaces
{
    public interface ICustomerAdapter
    {
        void Register(UserDto user);
        bool EmailExists(string email);
        Customer GetUserByEmail(string email);
        UserResponse Login(LoginDto request);
    }
}
