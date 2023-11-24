namespace Repositories.Interfaces
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        T ValidateLogin(string email, string password);
        bool HasRole(Guid userId, Guid roleId);
    }
}
