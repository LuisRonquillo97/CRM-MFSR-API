using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Dtos.Entities
{
    /// <summary>
    /// User DTO.
    /// </summary>
    public class UserDto : BaseEntityDTO
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
        public virtual List<UserRoleDto>? UserRoles { get; set; }
    }
}
