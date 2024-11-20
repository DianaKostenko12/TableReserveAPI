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
