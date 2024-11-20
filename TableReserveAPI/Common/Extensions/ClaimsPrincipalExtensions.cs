using System.Security.Claims;

namespace TableReserveAPI.Common.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            var userIdString = GetInfoByDataName(principal, "userId");
            return userIdString;
        }

        private static string GetInfoByDataName(ClaimsPrincipal principal, string name)
        {
            var data = principal.FindFirstValue(name);

            if (data == null)
            {
                throw new Exception($"No such data as {name} in Token");
            }

            return data;
        }
    }
}
