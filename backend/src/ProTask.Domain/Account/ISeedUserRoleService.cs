namespace ProTask.Domain.Account
{
    public interface ISeedUserRoleService
    {
        /// <summary>
        /// Include a user in a role
        /// </summary>
        /// <returns></returns>
        Task SeedUser();
        /// <summary>
        /// Include roles
        /// </summary>
        /// <returns></returns>
        Task SeedRoles();
        /// <summary>
        /// Return roles of a user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetRoles(string userName);
        /// <summary>
        /// Register an user in a role
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> Register(string userName, string roleName);
    }
}