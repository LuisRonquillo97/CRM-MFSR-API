using CRM_MFSR_API.Models.Dtos.Entities;

namespace CRM_MFSR_API.Models.Request.Role
{
    /// <summary>
    /// Request to search roles
    /// </summary>
    public class SearchRoleRequest
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
        /// Transform SearchRequest to RoleRequest.
        /// </summary>
        /// <returns>Role Entity</returns>
        public RoleDto ToRoleDto()
        {
            return new RoleDto { 
                Description = Description,
                Name = Name
            };

        }
    }
}
