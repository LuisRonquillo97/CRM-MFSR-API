namespace Entities.Models
{
    /// <summary>
    /// UserRole entity.
    /// </summary>
    /// <remarks>Pivot entity with Users and Roles</remarks>
    public class UserRole : BaseAttributes
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
        public virtual Role? Role { get; set; }
        /// <summary>
        /// User entity.
        /// </summary>
        public virtual User? User { get; set; }
    }
}
