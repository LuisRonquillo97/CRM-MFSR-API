namespace CRM_MFSR_API.Models.Dtos.Entities
{
    /// <summary>
    /// Role permission DTO.
    /// </summary>
    public class RolePermissionDto : BaseEntityDTO
    {
        /// <summary>
        /// Role Id.
        /// </summary>
        public Guid RoleId { get; set; }
        /// <summary>
        /// Permission Id.
        /// </summary>
        public Guid PermissionId { get; set; }
        /// <summary>
        /// Virtual object Role.
        /// </summary>
        public virtual RoleDto? Role { get; set; }
        /// <summary>
        /// Virtual object Permission.
        /// </summary>
        public virtual PermissionDto? Permission { get; set; }
    }
}
