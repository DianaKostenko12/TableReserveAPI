using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public static string[] GetRoles() => new string[] { Admin, User };

        public static bool IsRoleValid(this string role)
            => GetRoles().Contains(role);
    }
}
