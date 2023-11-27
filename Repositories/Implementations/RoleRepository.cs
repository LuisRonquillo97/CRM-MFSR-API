using Entities.Models;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLDB.Context;

namespace Repositories.Implementations
{
    /// <summary>
    /// Role repository. Inherits from BaseRepository
    /// </summary>
    public class RoleRepository : BaseRepository<Role>, IRoleRepository<Role>
    {
        /// <summary>
        /// DB Context.
        /// </summary>
        private SqlContext Context { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">DB Context.</param>
        public RoleRepository(SqlContext context) : base(context)
        {
            Context = context;
        }

        /// <summary>
        /// Updates data from a role already-saved record.
        /// </summary>
        /// <param name="entity">Data to update from the role</param>
        /// <returns>Role updated.</returns>
        public new Role Update(Role entity)
        {
            try
            {
                Role actualRole = this.GetById(entity.Id);
                actualRole.Name = entity.Name;
                actualRole.Description = entity.Description;
                actualRole.LastUpdatedAt = DateTime.Now;
                actualRole.LastUpdatedBy = entity.LastUpdatedBy;
                Context.Roles.Update(actualRole);
                Context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get a role with his permissions, given by his id.
        /// </summary>
        /// <param name="id">Role id.</param>
        /// <returns>Role and permissions.</returns>
        public new Role GetById(Guid id)
        {
            return Context.Roles.Include(x=>x.Permissions).FirstOrDefault(x => x.Id.Equals(id));
        }
        /// <summary>
        /// Gets all roles matching the search filter.
        /// </summary>
        /// <param name="filter">Role search to filter.</param>
        /// <returns>List of roles matching the search query.</returns>
        public new List<Role> GetAll(Role filter)
        {
            return Context.Roles.Where(x => x.IsActive && (x.Name.Contains(filter.Name) || x.Description.Contains(filter.Description))).ToList();
        }
    }
}
