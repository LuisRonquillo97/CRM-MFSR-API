using Entities.Models.Users;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using SQLDB.Context;

namespace Repositories.Implementations
{
    /// <summary>
    /// Role repository. Inherits from BaseRepository
    /// </summary>
    /// <remarks>
    /// Constructor.
    /// </remarks>
    /// <param name="context">DB Context.</param>
    public class RoleRepository(SqlContext context) : BaseRepository<Role>(context), IRoleRepository
    {
        /// <summary>
        /// Updates data from a role already-saved record.
        /// </summary>
        /// <remarks>Also saves all permissions that the role have.</remarks>
        /// <param name="entity">Data to update from the role.</param>
        /// <returns>Role updated.</returns>
        public override Role Update(Role entity)
        {
            try
            {
                Role actualRole = this.GetById(entity.Id);
                if (actualRole != null)
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
        public override Role GetById(Guid id)
        {
            return Context.Roles.Include(x => x.RolePermissions).ThenInclude(x => x.Permission).First(x => x.Id.Equals(id) && x.IsActive);
        }

        /// <summary>
        /// Gets all roles matching the search filter.
        /// </summary>
        /// <param name="filter">Role search to filter.</param>
        /// <returns>List of roles matching the search query.</returns>
        public override List<Role> GetAll(Role filter)
        {
            return
            [
                .. Context.Roles
                                .Where(x =>
                                x.IsActive && 
                                x.Name.Contains(filter.Name) &&
                                x.Description.Contains(filter.Description)
                                )
            ];
        }

        /// <summary>
        /// Deactivates a role with his permissions.
        /// </summary>
        /// <param name="id">Role Id.</param>
        /// <param name="deletedBy">Person who deactivates the role.</param>
        public override void Delete(Guid id, string deletedBy)
        {
            try
            {
                Role entity = GetById(id);
                if (entity != null)
                {
                    entity.IsActive = false;
                    entity.DeactivatedAt = DateTime.Now;
                    entity.DeactivatedBy = deletedBy;
                    entity.RolePermissions?.ForEach(x =>
                    {
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
