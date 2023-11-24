namespace CRM_MFSR_API.Models.Request.User
{
    public class UpdateRequest
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string UpdatedBy { get; set; }
        public required List<Guid> RoleIds { get; set; }
    }
}
