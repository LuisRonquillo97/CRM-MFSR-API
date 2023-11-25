using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Dtos.Entities
{
    /// <summary>
    /// Role Dto.
    /// </summary>
    public class RoleDto : BaseEntityDTO
    {
        /// <summary>
        /// Role name.
        /// </summary>
        [MaxLength(50)]
        public required string Name { get; set; }
        /// <summary>
        /// Role Description.
        /// </summary>
        [MaxLength(250)]
        public required string Description { get; set; }
        /// <summary>
        /// User Roles.
        /// </summary>
        public virtual List<UserRoleDto>? UserRoles { get; set; }
    }
}
