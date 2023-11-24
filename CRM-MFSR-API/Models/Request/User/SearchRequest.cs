namespace CRM_MFSR_API.Models.Request.User
{
    public class SearchRequest
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<string>? RoleIds { get; set; } = new List<string>();
    }
}
