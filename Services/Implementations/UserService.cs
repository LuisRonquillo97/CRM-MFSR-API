using Entities.Models.Users;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;

namespace Services.Implementations
{
    /// <summary>
    /// User Service.
    /// </summary>
    /// <remarks>Uses IUserService.</remarks>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="context">DB Connection.</param>
    public class UserService(SqlContext context) : BaseService<User>(new UserRepository(context)), IUserService
    {
        public new required UserRepository Repository = new(context);

        /// <summary>
        /// Login method.
        /// </summary>
        /// <param name="email">email to login.</param>
        /// <param name="password">password to login.</param>
        /// <returns>User data if the login was successfull.</returns>
        public User ValidateLogin(string email, string password)
        {
            return Repository.ValidateLogin(email, password);
        }
    }
}