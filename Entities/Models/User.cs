using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    /// <summary>
    /// User Entity.
    /// </summary>
    public class User : BaseAttributes
    {
        /// <summary>
        /// User email.
        /// </summary>
        [MaxLength(250)]
        public required string Email { get; set; }
        /// <summary>
        /// User password.
        /// </summary>
        [MaxLength(30)]
        public required string Password { get; set; }
        /// <summary>
        /// User fisrt name.
        /// </summary>
        [MaxLength(50)]
        public required string FirstName { get; set; }
        /// <summary>
        /// User last name.
        /// </summary>
        [MaxLength(50)]
        public required string LastName { get; set; }
        /// <summary>
        /// User roles.
        /// </summary>
        public virtual List<UserRole>? UserRoles { get; set; }
    }
}
