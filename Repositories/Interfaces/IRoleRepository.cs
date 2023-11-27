using Entities.Models;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface for role repository.
    /// </summary>
    /// <remarks>Inherits from the base repository</remarks>
    /// <typeparam name="T">DB Entity</typeparam>
    public interface IRoleRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
