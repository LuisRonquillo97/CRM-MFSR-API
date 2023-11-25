using Entities.Models;

namespace CRM_MFSR_API.Models.Request.User
{
    /// <summary>
    /// Data to use when you call /api/User/Update.
    /// </summary>
    public class UpdateRequest
    {
        /// <summary>
        /// Current user ID.
        /// </summary>
        public required Guid Id { get; set; }
        /// <summary>
        /// User first name.
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// User last name.
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// User email.
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// User password.
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// Person who updated the user.
        /// </summary>
        public required string UpdatedBy { get; set; }
        /// <summary>
        /// Role ID list.
        /// </summary>
        public required List<Guid> RoleIds { get; set; }
        public Entities.Models.User ToUserEntity()
        {
            List<UserRole> roles = [];
            this.RoleIds.ForEach(x => roles.Add(new UserRole { RoleId = x, UserId = this.Id, CreatedBy = this.UpdatedBy, LastUpdatedAt = DateTime.Now, LastUpdatedBy = this.UpdatedBy }));
            return new Entities.Models.User
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                LastUpdatedAt = DateTime.Now,
                LastUpdatedBy = this.UpdatedBy,
                UserRoles = roles
            };
        }
    }
}
