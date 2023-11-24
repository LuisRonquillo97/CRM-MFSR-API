namespace CRM_MFSR_API.Models.Responses.User
{
    /// <summary>
    /// Response for has role endpoint.
    /// </summary>
    public class HasRoleResponse(bool hasRole)
    {
        public bool HasRole { get; set; } = hasRole;
    }
}
