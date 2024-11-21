using DAL.Exceptions;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _manager;
        public UserService(UserManager<User> manager)
        {
            _manager = manager;
        }
        public async Task<User> GetUserById(string id)
        {
            var user = await _manager.FindByIdAsync(id);
            if (user == null)
            {
                throw new BusinessException(HttpStatusCode.NotFound, $"No user found with ID {id}.");
            }
            return user;
        }
    }
}
