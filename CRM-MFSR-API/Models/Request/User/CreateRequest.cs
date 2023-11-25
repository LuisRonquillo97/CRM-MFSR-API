
using Entities.Models;

namespace CRM_MFSR_API.Models.Request.User
{
    /// <summary>
    /// Data to use when you call /api/User/Create.
    /// </summary>
    public class CreateRequest
    {
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
        /// User Password.
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// Person who creates the user.
        /// </summary>
        public required string CreatedBy { get; set; }
        /// <summary>
        /// Role id's from his roles.
        /// </summary>
        public required List<Guid> RoleIds { get; set; }
        /// <summary>
        /// Transform this class to User Entity.
        /// </summary>
        /// <returns>User Entity</returns>
        public Entities.Models.User ToUserEntity()
        {
            Guid id = Guid.NewGuid();
            List<UserRole> roles = [];
            this.RoleIds.ForEach(x => roles.Add(new UserRole { RoleId = x, UserId = id, CreatedBy = this.CreatedBy }));
            return new Entities.Models.User
            {
                Id = id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                CreatedBy = this.CreatedBy,
                UserRoles = roles
            };
        }
    }
}
