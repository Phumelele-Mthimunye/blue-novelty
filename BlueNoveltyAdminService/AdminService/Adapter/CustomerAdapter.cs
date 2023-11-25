using Domain.Models.Dtos;
using Domain.Models.Entities;
using Domain.Models.Interfaces;
using SharedServices;

namespace AdminService.Adapter
{
    public class CustomerAdapter : ICustomerAdapter
    {
        private readonly IRepository<Customer, Guid> _repo;

        public CustomerAdapter(IRepository<Customer, Guid> repo) 
        { 
            _repo= repo;
        }

        public void Register(UserDto request)
        {
            var entity = new Customer();
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

        public Customer GetUserByEmail(string email)
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
