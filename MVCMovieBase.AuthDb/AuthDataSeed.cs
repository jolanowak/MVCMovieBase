using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace MVCMovieBase.AuthDb
{
    public class AuthDataSeed
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private const string AdminRoleName = "Admin";

        public AuthDataSeed(AuthDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task SeedAdminUser()
        {
            await CreateAdminRole();
            await CreateAdminUser();
            await _context.SaveChangesAsync();
        }

       private async Task CreateAdminUser()
        {
            var user = new IdentityUser
            {
                UserName = "globaladmin@moviebase.com",
                NormalizedUserName = "GLOBALADMIN",
                Email = "globaladmin@moviebase.com",
                NormalizedEmail = "GLOBALADMIN@MOVIEBASE.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

          

           // if (!_context.Users.Any(u => u.UserName == user.UserName))
            //{
               // await _userManager.CreateAsync(user, _config.GetValue<string>("AdminSecret"));
               // await _userManager.AddToRoleAsync(user, AdminRoleName);
            //}
        }

        private async Task CreateAdminRole()
        {
            if (!_context.Roles.Any(r => r.Name == AdminRoleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(AdminRoleName));
            }
        }
    }
}
