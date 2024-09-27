using Domain.Data;
using Domain.Models.Dtos;
using Domain.Models.Entities;
using Domain.Models.Interfaces.Adapters;
using Microsoft.EntityFrameworkCore;
using SharedServices;
using System;
using System.Linq;

namespace AdminService.Adapters
{
    public class ServiceProviderAdapter : IServiceProviderAdapter
    {
        private readonly AppDbContext _context;

        public ServiceProviderAdapter(AppDbContext context)
        {
            _context = context;
        }

        public void Register(UserDto request)
        {
            var entity = new Domain.Models.Entities.ServiceProvider(request);
            _context.ServiceProviders.Add(entity);
            _context.SaveChanges();
        }

        public bool EmailExists(string email)
        {
            var entity = GetUserByEmail(email);
            return entity != null;
        }

        public Domain.Models.Entities.ServiceProvider GetUserByEmail(string email)
        {
            return _context.ServiceProviders
                .FirstOrDefault(x => x.Email == email);
        }

        public UserResponse Login(LoginDto request)
        {
            return _context.ServiceProviders
                .Where(x => x.Email == request.Email)
                .Select(x => x.ToDomain())
                .FirstOrDefault();
        }
    }
}
