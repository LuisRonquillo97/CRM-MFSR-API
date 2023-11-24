using Entities.Models;
using Repositories.Implementations;

namespace Services.Interfaces
{
    public interface IUserService<T> : IBaseService<T> where T : BaseAttributes
    {
        public UserRepository Repository { get; set; }
        public bool HasRole(Guid userId, Guid roleId);
        public User ValidateLogin(string email, string password);
    }
}
