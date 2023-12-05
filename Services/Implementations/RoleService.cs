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
        public readonly RoleRepository Repository = new(context);

        /// <summary>
        /// Deactivates an existing <typeparamref name="Role"/> record on DB.
        /// </summary>
        /// <param name="id"><typeparamref name="Role"/> ID.</param>
        /// <param name="deletedBy">Person who deactivates <typeparamref name="Role"/></param>
        public override void Delete(Guid id, string deletedBy)
        {
            Repository.Delete(id, deletedBy);
        }

        /// <summary>
        /// Gets a list of <typeparamref name="Role"/> which matches the query.
        /// </summary>
        /// <param name="filter">Entity <typeparamref name="Role"/> used to filter.</param>
        /// <returns>List of <typeparamref name="Role"/> matching the query.</returns>
        public override List<Role> GetAll(Role filter)
        {
            return Repository.GetAll(filter);
        }

        /// <summary>
        /// Get an entity <typeparamref name="Role"/> by his <paramref name="id"/>
        /// </summary>
        /// <param name="id"><typeparamref name="Role"/> ID.</param>
        /// <returns>Entity <typeparamref name="Role"/></returns>
        public override Role GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Updates a <typeparamref name="Role"/> record.
        /// </summary>
        /// <param name="entity">Entity <typeparamref name="Role"/> with data to update.</param>
        /// <returns>Entity <typeparamref name="Role"/> updated.</returns>
        public override Role Update(Role entity)
        {
            return Repository.Update(entity);
        }

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
