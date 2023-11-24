using Repositories.Implementations;
using Repositories.Interfaces;
using SQLDB.Entities;

namespace Services.Interfaces
{
    public interface IUserService<T> : IBaseService<T> where T : BaseAttributes
    {
    }
}
