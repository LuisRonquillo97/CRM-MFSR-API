using Entities.Models;

namespace CRM_MFSR_API.Models.Dtos.Entities
{
    /// <summary>
    /// Permission DTO.
    /// </summary>
    public class PermissionDto : BaseEntityDTO
    {
        /// <summary>
        /// Permission internal key.
        /// </summary>
        public string Key { get; set; } = string.Empty;
        /// <summary>
        /// Permission name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Permission description.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Role entity relation.
        /// </summary>
        public virtual List<RolePermissionDto>? RolePermissions { get; set; }
    }
}
