namespace SQLDB.Entities
{
    public class UserRole : BaseAttributes
    {
        public required Guid RoleId { get; set; }
        public required Guid UserId { get; set; }
        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
