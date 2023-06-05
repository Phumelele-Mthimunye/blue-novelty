using AdminService.Models.Dtos;
using AdminService.Models.Entities;
using AdminService.Models.Interfaces;
using SharedServices;

namespace AdminService.Adapter
{
    public class UserAdapter : IUserAdapter
    {
        private readonly IRepository<User, Guid> _repo;

        public UserAdapter(IRepository<User, Guid> repo) 
        { 
            _repo= repo;
        }

        public void Register(UserDto request)
        {
            var entity = new User();
            entity.ToEntity(request);
            _repo.Add(entity);
            _repo.Save();
        }

        public bool EmailExists(string email)
        {
            var entity = GetUserByEmail(email);
            if(entity == null)
            {
                return false;
            }
            return true;
        }

        public User GetUserByEmail(string email)
        {
            return _repo.Get(x => x.Email == email).FirstOrDefault();
        }

        public UserResponse Login(LoginDto request)
        {
            return _repo.Get(x => x.Email == request.Email)
                .Select(x => x.ToDomain())
                .FirstOrDefault();
        }
    }
}
