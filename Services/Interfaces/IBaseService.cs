using Entities.Models;
using Repositories.Implementations;
using Repositories.Interfaces;

namespace Services.Interfaces
{
    /// <summary>
    /// Base service interface.
    /// </summary>
    /// <remarks>Inherits from IBaseRepository.</remarks>
    /// <typeparam name="T">Model BaseAttributes, or any of its inherits</typeparam>
    public interface IBaseService<T, Y> : IBaseRepository<T> where T : BaseAttributes where Y : BaseRepository<T>
    {
    }
}
