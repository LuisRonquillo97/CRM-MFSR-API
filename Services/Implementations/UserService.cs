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
        public readonly UserRepository Repository = new(context);

        /// <summary>
        /// Deactivates an existing <typeparamref name="User"/> record on DB.
        /// </summary>
        /// <param name="id"><typeparamref name="User"/> ID.</param>
        /// <param name="deletedBy">Person who deactivates <typeparamref name="User"/></param>
        public override void Delete(Guid id, string deletedBy)
        {
            Repository.Delete(id, deletedBy);
        }

        /// <summary>
        /// Gets a list of <typeparamref name="User"/> which matches the query.
        /// </summary>
        /// <param name="filter">Entity <typeparamref name="User"/> used to filter.</param>
        /// <returns>List of <typeparamref name="User"/> matching the query.</returns>
        public override List<User> GetAll(User filter)
        {
            return Repository.GetAll(filter);
        }

        /// <summary>
        /// Get an entity <typeparamref name="User"/> by his <paramref name="id"/>
        /// </summary>
        /// <param name="id"><typeparamref name="User"/> ID.</param>
        /// <returns>Entity <typeparamref name="User"/></returns>
        public override User GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Updates a <typeparamref name="User"/> record.
        /// </summary>
        /// <param name="entity">Entity <typeparamref name="User"/> with data to update.</param>
        /// <returns>Entity <typeparamref name="User"/> updated.</returns>
        public override User Update(User entity)
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
    }
}