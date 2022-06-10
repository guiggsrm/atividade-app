namespace ProTask.Domain.Account
{
    /// <summary>
    /// Interface to work with authentication of a user
    /// </summary>
    public interface IAuthenticate
    {
        /// <summary>
        /// Allow to authenticate a user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> Authenticate(string userName, string password);
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> RegisterUser(string userName, string password, string name, string lang, bool loginAfterRegister = true);
        /// <summary>
        /// Logout of a user
        /// </summary>
        /// <returns></returns>
        Task Logout();
        /// <summary>
        /// Get all users
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> Get<T>();
        /// <summary>
        /// Get user
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> GetUserName<T>(string userName);
    }
}