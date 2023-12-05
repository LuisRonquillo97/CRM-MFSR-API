using Entities.Models.Users;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface for role repository.
    /// </summary>
    /// <remarks>Inherits from the base repository</remarks>
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Validates if the user can login with his email and password.
        /// </summary>
        /// <param name="email">email.</param>
        /// <param name="password">password.</param>
        /// <returns>User data.</returns>
        User ValidateLogin(string email, string password);
    }
}
