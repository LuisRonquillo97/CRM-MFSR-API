using System.ComponentModel.DataAnnotations;

namespace SQLDB.Entities
{
    public class User : BaseAttributes
    {
        [MaxLength(250)]
        public required string Email { get; set; }
        [MaxLength(30)]
        public required string Password { get; set; }
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [MaxLength(50)]
        public required string LastName { get; set; }
        public virtual List<UserRole>? UserRoles { get; set; }
    }
}
