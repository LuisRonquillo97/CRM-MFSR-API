using Entities.Models.Users;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;

namespace Services.Implementations
{
    /// <summary>
    /// Role Service.
    /// </summary>
    /// <remarks>Implements IRoleService.</remarks>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="context">DB context.</param>
    public class RoleService(SqlContext context) : BaseService<Role>(new RoleRepository(context)), IRoleService
    {
        public new required RoleRepository Repository = new(context);

        /// <summary>
        /// Determinates if a provided role has a permission.
        /// </summary>
        /// <param name="RoleId">Role to search</param>
        /// <param name="permissionKey">permission key to search in role.</param>
        /// <returns>true/false</returns>
        public bool RoleHasPermission(Guid RoleId, string permissionKey)
        {
            return Repository.RoleHasPermission(RoleId, permissionKey);
        }
    }
}
