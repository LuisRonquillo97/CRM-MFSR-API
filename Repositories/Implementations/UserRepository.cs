using Entities.Models.Users;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using SQLDB.Context;

namespace Repositories.Implementations
{
    /// <summary>
    /// User Repository.
    /// </summary>
    /// <remarks>
    /// Constructor.
    /// </remarks>
    /// <param name="context">DBContext.</param>
    public class UserRepository(SqlContext context) : BaseRepository<User>(context), IUserRepository
    {
        /// <summary>
        /// Override of base GetAll. Gets all users with user roles and each role information.
        /// </summary>
        /// <param name="filter">Filters to apply.</param>
        /// <returns>Matching users query.</returns>
        public override List<User> GetAll(User filter)
        {
            List<Guid> roleIds = [];
            if (filter.UserRoles != null)
            {
                foreach (var item in filter.UserRoles)
                {
                    roleIds.Add(item.RoleId);
                }
            }
#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            List<User> users = Context.Users.Where(x => (x.Email.Contains(filter.Email) &&
            (x.FirstName.Contains(filter.FirstName) ||
            x.LastName.Contains(filter.LastName)) ||
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
        public override User GetById(Guid id)
        {
            return Context.Users.Include(x => x.UserRoles).FirstOrDefault(x => x.Id == id && x.IsActive) ?? throw new Exception($"User with ID {id} was not found.");
        }

        /// <summary>
        /// Update user data with roles.
        /// </summary>
        /// <param name="entity">Data to update</param>
        /// <returns>Record updated.</returns>
        public override User Update(User entity)
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
                    user.LastUpdatedBy = entity.LastUpdatedBy;
                    user.LastUpdatedAt = entity.LastUpdatedAt;
                    Context.Users.Update(user);
                    if (entity.UserRoles != null)
                    {
                        Context.UserRoles.Where(x => x.UserId == entity.Id).ExecuteDelete();
                        foreach (UserRole role in entity.UserRoles)
                        {
                            role.CreatedAt = DateTime.Now;
                            role.CreatedBy = entity.LastUpdatedBy;
                            Context.UserRoles.Add(role);
                        }
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
        public override void Delete(Guid id, string deletedBy)
        {
            try
            {
                User entity = GetById(id);
                entity.IsActive = false;
                entity.DeactivatedAt = DateTime.Now;
                entity.DeactivatedBy = deletedBy;
                entity.UserRoles?.ForEach(x =>
                {
                    x.IsActive = false;
                    x.DeactivatedBy = deletedBy;
                    x.DeactivatedAt = DateTime.Now;
                });
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
        public User ValidateLogin(string email, string password = "")
        {
            try
            {
                User? data = Context.Users
                    .Include(x => x.UserRoles)
                    .FirstOrDefault(x => EF.Functions.Collate(x.Email, "SQL_Latin1_General_CP1_CS_AS") == email && EF.Functions.Collate(x.Password, "SQL_Latin1_General_CP1_CS_AS") == password && x.IsActive);
                return data ?? throw new Exception("Email/Password was incorrect.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
