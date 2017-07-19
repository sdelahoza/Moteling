using Moteling.WEB.Helpers;
using System.Linq;
using System.Security.Claims;

namespace Moteling.WEB.Extension
{
    public static class UserExtension
    {
        public static string UserName(this ClaimsPrincipal user)
        {
            return (user.Identity.IsAuthenticated) ? user.Claims.FirstOrDefault(c => c.Type == IdentityClaimTypes.UserName).Value : "";
        }

        public static string Email(this ClaimsPrincipal user)
        {
            return (user.Identity.IsAuthenticated) ? user.Claims.FirstOrDefault(c => c.Type == IdentityClaimTypes.Email).Value : "";
        }

        public static string FullName(this ClaimsPrincipal user)
        {
            return (user.Identity.IsAuthenticated) ? user.Claims.FirstOrDefault(c => c.Type == IdentityClaimTypes.FullName).Value : "";
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return (user.Identity.IsAuthenticated) ? bool.Parse(user.Claims.FirstOrDefault(c => c.Type == IdentityClaimTypes.IsAdmin).Value) : false;
        }
    }
}
