using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;
using SQLDB.Entities;

namespace Services.Implementations
{
    public class UserService : IUserService<User>
    {
        public BaseRepository<User> Repository { get; set; }
        public UserRepository UserRepository { get; set; }

        public UserService(SqlContext context)
        {
            Repository = new UserRepository(context);
            UserRepository = new UserRepository(context);
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
            return UserRepository.GetAll(filter);
        }

        public User GetById(Guid id)
        {
            return UserRepository.GetById(id);
        }

        public User Update(User entity)
        {
            return UserRepository.Update(entity);
        }
    }
}