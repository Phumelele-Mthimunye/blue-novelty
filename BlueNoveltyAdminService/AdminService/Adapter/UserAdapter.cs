using AdminService.Data;
using AdminService.Models.Dtos;
using AdminService.Models.Entities;
using AdminService.Models.Interfaces;
using AdminService.SharedServices;
using BlueNoveltyAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

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
    }
}
