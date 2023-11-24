using Entities.Models;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;

namespace Services.Implementations
{
    public class UserService : IUserService<User>
    {
        public UserRepository Repository { get; set; }

        public UserService(SqlContext context)
        {
            Repository = new UserRepository(context);
        }

        public User Create(User entity)
        {
            return Repository.Create(entity);
        }

        public void Delete(Guid id, string deletedBy)
        {
            Repository.Delete(id, deletedBy);
        }

        public List<User> GetAll(User filter)
        {
            return Repository.GetAll(filter);
        }

        public User GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        public User Update(User entity)
        {
            return Repository.Update(entity);
        }

        public bool HasRole(Guid userId, Guid roleId)
        {
            return Repository.HasRole(userId, roleId);
        }

        public User ValidateLogin(string email, string password)
        {
            return Repository.ValidateLogin(email, password);
        }
    }
}