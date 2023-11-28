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
        /// <remarks>Also saves all permissions that the role have.</remarks>
        /// <param name="entity">Data to update from the role.</param>
        /// <returns>Role updated.</returns>
        public new Role Update(Role entity)
        {
            try
            {
                Role actualRole = this.GetById(entity.Id);
                if(actualRole != null)
                {
                    actualRole.Name = entity.Name;
                    actualRole.Description = entity.Description;
                    actualRole.LastUpdatedAt = DateTime.Now;
                    actualRole.LastUpdatedBy = entity.LastUpdatedBy;
                    Context.Roles.Update(actualRole);
                    if (entity.RolePermissions != null)
                    {
                        Context.RolePermissions.Where(x => x.RoleId.Equals(entity.Id)).ExecuteDelete();
                        foreach (var permission in entity.RolePermissions)
                        {
                            permission.CreatedBy = entity.CreatedBy;
                            Context.RolePermissions.Add(permission);
                        }
                    }
                    Context.SaveChanges();
                    actualRole = this.GetById(entity.Id);
                    return actualRole;
                }
                throw new Exception($"The role \"{entity.Name}\" was not found.");
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
            return Context.Roles.Include(x=>x.RolePermissions).ThenInclude(x=>x.Permission).FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets all roles matching the search filter.
        /// </summary>
        /// <param name="filter">Role search to filter.</param>
        /// <returns>List of roles matching the search query.</returns>
        public new List<Role> GetAll(Role filter)
        {
            return Context.Roles.Include(x=>x.RolePermissions)
                .Where(x => 
                x.IsActive && (x.Name.Contains(filter.Name) || 
                x.Description.Contains(filter.Description)))
                .ToList();
        }

        /// <summary>
        /// Deactivates a role with his permissions.
        /// </summary>
        /// <param name="id">Role Id.</param>
        /// <param name="deletedBy">Person who deactivates the role.</param>
        public new void Delete(Guid id, string deletedBy)
        {
            try
            {
                Role entity = GetById(id);
                if(entity != null)
                {
                    entity.IsActive = false;
                    entity.DeactivatedAt = DateTime.Now;
                    entity.DeactivatedBy = deletedBy;
                    entity.RolePermissions.ForEach(x => {
                        x.IsActive = false;
                        x.DeactivatedAt = DateTime.Now;
                        x.DeactivatedBy = deletedBy;
                    });
                    Context.Update(entity);
                    Context.SaveChanges();
                }
                else
                {
                    throw new Exception($"The role with ID \"{id}\" was not found.");
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Determinates if a role has a certain permission.
        /// </summary>
        /// <param name="roleId">Role ID.</param>
        /// <param name="permissionName">Permission to search.</param>
        /// <returns>true if it has, false if not.</returns>
        public bool RoleHasPermission(Guid roleId, string permissionName)
        {
            return Context.RolePermissions.Include(x => x.Permission).FirstOrDefault(x => x.RoleId.Equals(roleId) && x.Permission.Key.Equals(permissionName)) != null;
        }
    }
}
