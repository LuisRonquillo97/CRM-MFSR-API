using Entities.Models;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;
using SQLDB.Migrations;

namespace Services.Implementations
{
    /// <summary>
    /// User Service.
    /// </summary>
    /// <remarks>Uses IUserService.</remarks>
    public class UserService : IUserService<User>
    {
        /// <summary>
        /// Repository of the user who interacts with the database
        /// </summary>
        public UserRepository Repository { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">DB Connection.</param>
        public UserService(SqlContext context)
        {
            Repository = new UserRepository(context);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="entity">User to Add.</param>
        /// <returns>Added user.</returns>
        public User Create(User entity)
        {
            return Repository.Create(entity);
        }

        /// <summary>
        /// Deactivates an existing user.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="deletedBy">Person who deactivate the record.</param>
        public void Delete(Guid id, string deletedBy)
        {
            Repository.Delete(id, deletedBy);
        }

        /// <summary>
        /// Gets all users with user roles and each role information.
        /// </summary>
        /// <param name="filter">Search filter</param>
        /// <returns>List of users.</returns>
        public List<User> GetAll(User filter)
        {
            return Repository.GetAll(filter);
        }

        /// <summary>
        /// Gets an user by his ID.
        /// </summary>
        /// <param name="id">user ID.</param>
        /// <returns>User.</returns>
        public User GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="entity">User with data to update.</param>
        /// <returns>Updated User.</returns>
        public User Update(User entity)
        {
            return Repository.Update(entity);
        }

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

        public List<Permission> GetPermissions(Guid userId)
        {
            return Repository.GetPermissions(userId);
        }
    }
}