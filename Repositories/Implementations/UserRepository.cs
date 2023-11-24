using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using SQLDB.Context;

namespace Repositories.Implementations
{
    /// <summary>
    /// User Repository.
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository<User>
    {
        /// <summary>
        /// DBContext.
        /// </summary>
        SqlContext Context;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">DBContext.</param>
        public UserRepository(SqlContext context) : base(context)
        {
            Context = context;
        }
        /// <summary>
        /// Override of base GetAll. Gets all users with user roles and each role information.
        /// </summary>
        /// <param name="filter">Filters to apply.</param>
        /// <returns>Matching users query.</returns>
        public new List<User> GetAll(User filter)
        {
            List<Guid> roleIds = new List<Guid>();
            if (filter.UserRoles != null)
            {
                foreach (var item in filter.UserRoles)
                {
                    roleIds.Add(item.RoleId);
                }
            }
#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            List<User> users = Context.Users.Where(x => (x.Email.Contains(filter.Email) ||
            x.FirstName.Contains(filter.FirstName) ||
            x.LastName.Contains(filter.LastName) ||
            x.UserRoles.Any(y => roleIds.Contains(y.RoleId))) &&
            x.IsActive == true
            ).Include(x => x.UserRoles).ThenInclude(x => x.Role).ToList();
#pragma warning restore CS8604 // Posible argumento de referencia nulo
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
            return users;
        }
        /// <summary>
        /// Gets user data, with roles.
        /// </summary>
        /// <param name="id">User UUID</param>
        /// <returns>User data.</returns>
        public new User GetById(Guid id)
        {
            return Context.Users.Include(x => x.UserRoles).ThenInclude(x=>x.Role).First(x => x.Id == id);
        }
        /// <summary>
        /// Update user data with roles.
        /// </summary>
        /// <param name="entity">Data to update</param>
        /// <returns>Record updated.</returns>
        public new User Update(User entity)
        {
            try
            {

                User user = this.GetById(entity.Id);
                if (user != null)
                {
                    user.FirstName = entity.FirstName;
                    user.LastName = entity.LastName;
                    user.Email = entity.Email;
                    user.Password = entity.Password;
                    Context.Users.Update(user);
                    Context.UserRoles.Where(x => x.UserId == entity.Id).ExecuteDelete();
                    foreach (UserRole role in entity.UserRoles)
                    {
                        Context.UserRoles.Add(role);
                    }
                    Context.SaveChanges();
                    //get the updated user.
                    user = this.GetById(entity.Id);
                    return user;
                }
                throw new Exception("User not found");
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Deactivate the provided user.
        /// </summary>
        /// <param name="id">User UUID.</param>
        /// <param name="deletedBy">Person who deactivate the record.</param>
        public new void Delete(Guid id, string deletedBy)
        {
            try
            {
                User entity = GetById(id);
                entity.IsActive = false;
                entity.DeactivatedAt = DateTime.Now;
                entity.DeactivatedBy = deletedBy;
                entity.UserRoles.ForEach(x => x.IsActive = false);
                Context.Update(entity);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Validates if the Login is successfull or not.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <param name="password">Password for user.</param>
        /// <returns>User.</returns>
        public User ValidateLogin(string email, string password)
        {
            try
            {
                User data = Context.Users.FirstOrDefault(x=>x.Email == email && x.Password == password && x.IsActive);
                if(data == null) {
                    throw new Exception("Email/Password was incorrect.");
                }
                return data;
            }catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Determinates if the user has an especific role.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="roleId">Role ID to validate.</param>
        /// <returns>true if the user has the role, false if not.</returns>
        public bool HasRole(Guid userId, Guid roleId)
        {
            return this.GetById(userId).UserRoles.FirstOrDefault(x=>x.RoleId == roleId) != null;
        }
    }
}
