using Microsoft.AspNetCore.Identity;

namespace ProTask.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() {}
        public ApplicationUser(string userName, string name)
        {
            UserName = userName;
            Email = userName;
            Name = name.Trim();
        }
        public ApplicationUser(string userName, string name, string lang) : this(userName, name)
        {
            Lang = lang;
        }

        public string Name { get; set; }
        public string Lang { get; set; }
    }
}