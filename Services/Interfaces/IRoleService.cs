using Entities.Models.Users;
using Repositories.Implementations;

namespace Services.Interfaces
{
    public interface IRoleService : IBaseService<Role,RoleRepository>
    {
        
        /// <summary>
        /// Determinates if a provided role has a permission.
        /// </summary>
        /// <param name="RoleId">Role to search</param>
        /// <param name="permissionKey">permission key to search in role.</param>
        /// <returns>true/false</returns>
        public bool RoleHasPermission(Guid RoleId, string permissionKey);
    }
}
