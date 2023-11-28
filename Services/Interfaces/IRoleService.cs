using Entities.Models;
using Repositories.Implementations;

namespace Services.Interfaces
{
    public interface IRoleService<T> : IBaseService<T> where T : BaseAttributes
    {
        /// <summary>
        /// Role Repository to interact with DB.
        /// </summary>
        public RoleRepository Repository { get; set; }
        /// <summary>
        /// Determinates if a provided role has a permission.
        /// </summary>
        /// <param name="RoleId">Role to search</param>
        /// <param name="permissionKey">permission key to search in role.</param>
        /// <returns>true/false</returns>
        public bool RoleHasPermission(Guid RoleId, string permissionKey);
    }
}
