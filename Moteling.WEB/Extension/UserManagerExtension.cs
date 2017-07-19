using Microsoft.AspNetCore.Identity;
using Moteling.WEB.Helpers;
using Moteling.WEB.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Moteling.WEB.Extension
{
    public static class UserManagerExtension
    {
        public static async Task<IdentityResult> AddIdentityClaims(this UserManager<ApplicationUser> _userManager, 
            ApplicationUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(IdentityClaimTypes.UserName, user.UserName),
                new Claim(IdentityClaimTypes.Email, user.Email),
                new Claim(IdentityClaimTypes.FullName, user.FullName),
                new Claim(IdentityClaimTypes.IsAdmin, user.IsAdmin.ToString())
            };
            return await _userManager.AddClaimsAsync(user, claims);
        }
    }
}
