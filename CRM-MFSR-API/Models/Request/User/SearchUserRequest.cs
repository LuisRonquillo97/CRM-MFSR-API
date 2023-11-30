using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Request.User
{
    /// <summary>
    /// Data to use when you call /api/User/Search.
    /// </summary>
    public class SearchUserRequest
    {
        /// <summary>
        /// User email.
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// User first name.
        /// </summary>
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// User last name.
        /// </summary>
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Role IDs from user.
        /// </summary>
        public List<Guid>? RoleIds { get; set; } = new List<Guid>();
        /// <summary>
        /// Convert this request to User entity.
        /// </summary>
        /// <returns></returns>
        public Entities.Models.Users.User ToUserEntity()
        {
            return new Entities.Models.Users.User
            {
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                CreatedBy = string.Empty,
                Password = string.Empty,
            };
        }
    }
}
