using Repositories.Implementations;
using Repositories.Interfaces;
using SQLDB.Entities;

namespace Services.Interfaces
{
    public interface IBaseService<T> : IBaseRepository<T> where T : BaseAttributes 
    {
        BaseRepository<T> Repository { get; set; }
    }
}
