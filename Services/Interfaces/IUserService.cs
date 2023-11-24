using Entities.Models;
using Repositories.Implementations;

namespace Services.Interfaces
{
    /// <summary>
    /// User service interface.
    /// </summary>
    /// <remarks>Inherits from IBaseService.</remarks>
    /// <typeparam name="T">Model BaseAttributes, or any of its inherits</typeparam>
    public interface IUserService<T> : IBaseService<T> where T : BaseAttributes
    {
        /// <summary>
        /// User Repository to interact with DB.
        /// </summary>
        public UserRepository Repository { get; set; }

        /// <summary>
        /// Determinates if an especific user, has an especific role.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="roleId">Role ID.</param>
        /// <returns>boolean.</returns>
        public bool HasRole(Guid userId, Guid roleId);

        /// <summary>
        /// Login method.
        /// </summary>
        /// <param name="email">email.</param>
        /// <param name="password">password.</param>
        /// <returns>User if login was successfull.</returns>
        public User ValidateLogin(string email, string password);
    }
}
