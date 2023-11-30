using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Users
{
    /// <summary>
    /// Role Entity.
    /// </summary>
    public class Role : BaseAttributes
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
        public virtual List<UserRole>? UserRoles { get; set; }
        /// <summary>
        /// Permissions per role.
        /// </summary>
        public virtual List<RolePermission>? RolePermissions { get; set; }
    }
}
