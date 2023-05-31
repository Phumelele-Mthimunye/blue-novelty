using AdminService.Enums;
using AdminService.Models.Dtos;
using AdminService.Models.Interfaces;
using AdminService.SharedServices;
using BlueNoveltyAdminService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
                if (request.ConfirmPassword == request.Password)
                {
                    _adapter.Register(request);
                    /*using (HMACSHA512 hmac = new HMACSHA512())
                    {
                        user.PasswordSalt = hmac.Key;
                        user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                    }*/
                }
                
                return new GenericResponse<string>(MessageOutcome.Success);
            }
            catch
            {
                return new GenericResponse<string>(MessageOutcome.Success);
            }
            /*var user = new User
            {
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserType = model.UserType,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
            };
            if (model.ConfirmPassword == model.Password)
            {
                using (HMACSHA512 hmac = new HMACSHA512())
                {
                    user.PasswordSalt = hmac.Key;
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                }
            }
            else
            {
                return BadRequest();
            }

            _context.User.Add(user);
            _context.SaveChanges();

            return Ok(user);*/
        }
    }
}
