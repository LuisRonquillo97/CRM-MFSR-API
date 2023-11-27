using Entities.Models;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /// <summary>
    /// Role Service.
    /// </summary>
    /// <remarks>Implements IRoleService.</remarks>
    public class RoleService : IRoleService<Role>
    {
        /// <summary>
        /// Repository to interact with DB.
        /// </summary>
        public RoleRepository Repository { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">DB Context.</param>
        public RoleService(SqlContext context) {
            Repository = new RoleRepository(context);
        }

        /// <summary>
        /// Adds a new role to the DB.
        /// </summary>
        /// <param name="entity">Role to add.</param>
        /// <returns>Role added.</returns>
        public Role Create(Role entity)
        {
            return Repository.Create(entity);
        }

        /// <summary>
        /// Deactivate an exising role in the DB.
        /// </summary>
        /// <param name="id">Role ID</param>
        /// <param name="deletedBy">Person Who deactivate the role.</param>
        public void Delete(Guid id, string deletedBy)
        {
            Repository.Delete(id, deletedBy);
        }

        /// <summary>
        /// Get all roles by the provided filter.
        /// </summary>
        /// <param name="filter">Role filter.</param>
        /// <returns>List of roles.</returns>
        public List<Role> GetAll(Role filter)
        {
            return Repository.GetAll(filter);
        }

        /// <summary>
        /// Get a role by his ID.
        /// </summary>
        /// <param name="id">Role UUID.</param>
        /// <returns>Role.</returns>
        public Role GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Update an existing role.
        /// </summary>
        /// <param name="entity">New role data.</param>
        /// <returns>Role updated.</returns>
        public Role Update(Role entity)
        {
            return Repository.Update(entity);
        }
    }
}
