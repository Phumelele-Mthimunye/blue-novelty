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
    public class CustomerAdapter : ICustomerAdapter
    {
        private readonly AppDbContext _context;

        public CustomerAdapter(AppDbContext context)
        {
            _context = context;
        }

        public void Register(UserDto request)
        {
            var entity = new Customer(request);
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public bool EmailExists(string email)
        {
            var entity = GetUserByEmail(email);
            return entity != null;
        }

        public Customer GetUserByEmail(string email)
        {
            return _context.Customers
                .FirstOrDefault(x => x.Email == email);
        }

        public UserResponse Login(LoginDto request)
        {
            return _context.Customers
                .Where(x => x.Email == request.Email)
                .Select(x => x.ToDomain())
                .FirstOrDefault();
        }
    }
}
