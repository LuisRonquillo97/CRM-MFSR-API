using Entities.Models;
using Repositories.Interfaces;

namespace Services.Interfaces
{
    /// <summary>
    /// Base service interface.
    /// </summary>
    /// <remarks>Inherits from IBaseRepository.</remarks>
    /// <typeparam name="T">Model BaseAttributes, or any of its inherits</typeparam>
    public interface IBaseService<T> : IBaseRepository<T> where T : BaseAttributes
    {

    }
}
