namespace CRM_MFSR_API.Models.Dtos.Entities
{
    /// <summary>
    /// User Role Dto.
    /// </summary>
    public class UserRoleDto : BaseEntityDTO
    {
        /// <summary>
        /// Role ID.
        /// </summary>
        public required Guid RoleId { get; set; }
        /// <summary>
        /// User ID.
        /// </summary>
        public required Guid UserId { get; set; }
        /// <summary>
        /// Role entity.
        /// </summary>
        public virtual RoleDto? Role { get; set; }
        /// <summary>
        /// User entity.
        /// </summary>
        public virtual UserDto? User { get; set; }
    }
}
