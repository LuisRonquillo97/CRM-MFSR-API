using SQLDB.Context;
using SQLDB.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

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
        /// DBContext.
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(SqlContext context) : base(context)
        {
            Context = context;
        }
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
            List<User> users = Context.Users.Where(x => x.Email.Contains(filter.Email) ||
            x.FirstName.Contains(filter.FirstName) ||
            x.LastName.Contains(filter.LastName) ||
            x.UserRoles.Any(y => roleIds.Contains(y.RoleId)) &&
            x.IsActive == true
            ).Include(x=>x.UserRoles).ThenInclude(x=>x.Role).ToList();
#pragma warning restore CS8604 // Posible argumento de referencia nulo
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
            return users;
        }
        public new User GetById(Guid id)
        {
            return Context.Users.Include(x=>x.UserRoles).First(x => x.Id == id);
        }
        public new User Update(User entity)
        {
            try
            {

                User user = this.GetById(entity.Id);
                if (user != null)
                {
                    List<UserRole> roles = new List<UserRole>();
                    entity.UserRoles.ForEach(x => roles.Add(new UserRole { RoleId = x.RoleId, UserId = entity.Id, CreatedAt = DateTime.Now, CreatedBy = entity.LastUpdatedBy ?? string.Empty }));
                    user.FirstName = entity.FirstName;
                    user.LastName = entity.LastName;
                    user.Email = entity.Email;
                    user.Password = entity.Password;
                    user.UserRoles = roles;
                    Context.Users.Update(user);
                    Context.SaveChanges();
                    return user;
                }
                throw new Exception("User not found");
            }catch (Exception)
            {
                throw;
            }
            
        }
        public User HasRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public User ValidateLogin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
