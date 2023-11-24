using Entities.Models;
using Repositories.Interfaces;

namespace Services.Interfaces
{
    public interface IBaseService<T> : IBaseRepository<T> where T : BaseAttributes
    {

    }
}
