using Entities.Models.Users;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface for role repository.
    /// </summary>
    /// <remarks>Inherits from the base repository</remarks>
    public interface IRoleRepository : IBaseRepository<Role>
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
