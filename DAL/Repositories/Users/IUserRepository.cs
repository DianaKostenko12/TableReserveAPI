using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Users
{
    public interface IUserRepository
    {
        IEnumerable<IdentityUser> GetUsers();
        IdentityUser GetUserById(int id);
        IdentityUser GetUserByEmail(string email);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool Save();
    }
}
