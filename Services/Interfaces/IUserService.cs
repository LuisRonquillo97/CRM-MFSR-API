using Entities.Models;
using Entities.Models.Users;
using Repositories.Implementations;

namespace Services.Interfaces
{
    /// <summary>
    /// User service interface.
    /// </summary>
    /// <remarks>Inherits from IBaseService.</remarks>
    /// <typeparam name="T">Base repository, or any of its inherits</typeparam>
    public interface IUserService : IBaseService<User, UserRepository>
    {
        /// <summary>
        /// Login method.
        /// </summary>
        /// <param name="email">email.</param>
        /// <param name="password">password.</param>
        /// <returns>User if login was successfull.</returns>
        public User ValidateLogin(string email, string password);
    }
}
