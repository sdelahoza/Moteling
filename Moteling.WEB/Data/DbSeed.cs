using Microsoft.AspNetCore.Identity;
using Moteling.WEB.Models;

namespace Moteling.WEB.Data
{
    public static class DbSeed
    {
        public static async void AddAdminAsync(ApplicationDbContext _context, 
            UserManager<ApplicationUser> _userManager)
        {
            _context.Database.EnsureCreated();

            var user = await _userManager.FindByNameAsync("admin");
            if (user == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FullName = "Admin",
                    IsAdmin =  true
                };
                var result = await _userManager.CreateAsync(admin, "admin");
            }
        }
    }
}
