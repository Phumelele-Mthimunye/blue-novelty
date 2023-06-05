using AdminService.Enums;
using AdminService.Models.Dtos;
using AdminService.Models.Interfaces;
using SharedServices;
using SharedServices.Enums;

namespace AdminService.Services
{
    public class UserService: IUserService
    {
        private IUserAdapter _adapter;

        public UserService(IUserAdapter adapter)
        {
            _adapter = adapter;
        }

        public GenericResponse<string> Register(UserDto request)
        {
            try
            {
                _adapter.Register(request);
                return new GenericResponse<string>(MessageOutcome.Success);
            }
            catch
            {
                return new GenericResponse<string>(MessageOutcome.Success);
            }
        }
    }
}
