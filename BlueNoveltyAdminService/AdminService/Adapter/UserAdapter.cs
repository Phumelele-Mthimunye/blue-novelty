using AdminService.Data;
using AdminService.Models.Interfaces;
using BlueNoveltyAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminService.Adapter
{
    public class UserAdapter : IUserAdapter
    {
        private readonly AppDbContext _context;
        public UserAdapter(AppDbContext context) 
        { 
            _context= context;
        }
        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }
    }
}
