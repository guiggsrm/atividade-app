using Microsoft.AspNetCore.Identity;
using ProTask.Domain.Account;
using ProTask.Domain.Exceptions;

namespace ProTask.Infra.Data.Identity
{
    public class SeedUserRoleService : ISeedUserRoleService
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly IAuthenticate _authenticateService;
        public SeedUserRoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IAuthenticate autenticate)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authenticateService = autenticate;
        }
        public async Task SeedRoles()
        {
            DomainValidationException.When(!(await RegisterUserInRoleIfNotExistsAsync("user@protask.com", "User", "User")), "User could't be include in a role");
            DomainValidationException.When(!(await RegisterUserInRoleIfNotExistsAsync("admin@protask.com", "Admin", "Admin")), "Admin could't be include in a role");
        }

        public async Task SeedUser()
        {
            DomainValidationException.When(!(await CreateIfNotExistsAsync("User")), "Role 'User' could't be created");
            DomainValidationException.When(!(await CreateIfNotExistsAsync("Admin")), "Role 'Admin' could't be created");
        }

        public async Task<IEnumerable<string>> GetRoles(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user == null)
                return new List<string>();
            return await _userManager.GetRolesAsync(user);
        }

        private async Task<bool> CreateIfNotExistsAsync(string roleName)
        {
            if(!(await _roleManager.RoleExistsAsync(roleName)))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                return result.Succeeded;
            }
            return true;
        }

        private async Task<bool> RegisterUserInRoleIfNotExistsAsync(string userName, string name, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user != null)
            {
                if (_authenticateService.RegisterUser(userName, string.Format("{0}}!proTask1", userName.Substring(0, userName.IndexOf("@"))), name, "en", false).Result) 
                {
                    return await Register(userName, roleName);
                }
            }
            return true;
        }

        public async Task<bool> Register(string userName, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(_userManager.FindByEmailAsync(userName).Result, roleName);
            return result.Succeeded;
        }
    }
}