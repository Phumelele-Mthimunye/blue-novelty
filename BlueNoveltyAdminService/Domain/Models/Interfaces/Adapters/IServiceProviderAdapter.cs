using Domain.Models.Dtos;
using Domain.Models.Entities;

namespace Domain.Models.Interfaces.Adapters
{
    public interface IServiceProviderAdapter
    {
        void Register(UserDto user);
        bool EmailExists(string email);
        Domain.Models.Entities.ServiceProvider GetUserByEmail(string email);
        UserResponse Login(LoginDto request);
    }
}
