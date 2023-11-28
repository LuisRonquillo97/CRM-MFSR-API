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
        /// <summary>
        /// Determinates if the provided role has a specific permission.
        /// </summary>
        /// <param name="roleId">Role Id.</param>
        /// <param name="permissionName">Permission name.</param>
        /// <returns>true/false.</returns>
        public bool RoleHasPermission(Guid roleId, string permissionName);
    }
}
