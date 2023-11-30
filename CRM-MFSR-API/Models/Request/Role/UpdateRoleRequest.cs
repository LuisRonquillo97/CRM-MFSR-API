using CRM_MFSR_API.Models.Dtos.Entities;

namespace CRM_MFSR_API.Models.Request.Role
{
    /// <summary>
    /// Request to update roles.
    /// </summary>
    public class UpdateRoleRequest
    {
        /// <summary>
        /// Role Id.
        /// </summary>
        public required Guid RoleId { get; set; }
        /// <summary>
        /// Role name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Role description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Person who updated the role.
        /// </summary>
        public string UpdatedBy { get; set; } = string.Empty;
        /// <summary>
        /// List of permission Ids.
        /// </summary>
        public List<Guid> Permissions { get; set; } = [];

        /// <summary>
        /// Transform CreateRequest to Role entity.
        /// </summary>
        /// <returns>Role dto Entity</returns>
        public RoleDto ToRoleDto()
        {
            List<RolePermissionDto> roles = [];
            foreach (Guid item in Permissions)
            {
                roles.Add(new RolePermissionDto
                {
                    LastUpdatedAt = DateTime.Now,
                    LastUpdatedBy = UpdatedBy,
                    PermissionId = item,
                    RoleId = RoleId
                });
            }
            return new RoleDto
            {
                Description = Description,
                Name = Name,
                Id = RoleId,
                LastUpdatedAt = DateTime.Now,
                LastUpdatedBy = UpdatedBy,
                RolePermissions = roles
            };

        }
    }
}
