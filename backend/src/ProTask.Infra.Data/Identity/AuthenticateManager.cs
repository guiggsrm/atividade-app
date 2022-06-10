using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProTask.Domain.Account;
using ProTask.Infra.Data.DTO;

namespace ProTask.Infra.Data.Identity
{
    public class AuthenticateManager : IAuthenticate
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticateManager(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return result.Succeeded;
        }

        public IEnumerable<T> Get<T>()
        {
                var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, T>();
            });
            var mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<IEnumerable<T>>( _userManager.Users.ToList());
        }

        public async Task<T> GetUserName<T>(string userName)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, T>();
            });
            var mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<T>((await _userManager.FindByNameAsync(userName)));
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string userName, string password, string name, string lang, bool loginAfterRegister = true)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser(userName, name, lang), password);
            if(result.Succeeded && loginAfterRegister)
                return await Authenticate(userName, password);
            
            return result.Succeeded;
        }
    }
}