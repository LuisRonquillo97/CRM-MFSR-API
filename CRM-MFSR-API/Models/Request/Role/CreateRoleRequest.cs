using CRM_MFSR_API.Models.Dtos.Entities;
using Entities.Models.Users;

namespace CRM_MFSR_API.Models.Request.Role
{
    /// <summary>
    /// Create role request.
    /// </summary>
    public class CreateRoleRequest
    {
        /// <summary>
        /// Role name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Role description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Person who created the role.
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;
        /// <summary>
        /// List of permission Ids.
        /// </summary>
        public List<Guid> Permissions { get; set; } = [];

        /// <summary>
        /// Transform CreateRequest to Role entity.
        /// </summary>
        /// <returns>Role Entity</returns>
        public RoleDto ToRoleDto()
        {
            Guid roleId = Guid.NewGuid();
            List<RolePermissionDto> roles = [];
            foreach (Guid item in Permissions)
            {
                roles.Add(new RolePermissionDto
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = CreatedBy,
                    PermissionId = item,
                    RoleId = roleId
                });
            }
            return new RoleDto
            {
                Description = Description,
                Name = Name,
                Id = roleId,
                CreatedAt = DateTime.Now,
                CreatedBy = CreatedBy,
                IsActive = true,
                RolePermissions = roles
            };

        }
    }
}
