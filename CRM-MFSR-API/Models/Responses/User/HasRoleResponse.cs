namespace CRM_MFSR_API.Models.Responses.User
{
    /// <summary>
    /// Response for has role endpoint.
    /// </summary>
    public class HasRoleResponse(bool hasRole, Guid userId, Guid roleId)
    {
        /// <summary>
        /// User ID
        /// </summary>
        public Guid UserID { get; set; } = userId;
        /// <summary>
        /// Role ID
        /// </summary>
        public Guid RoleID { get; set; } = roleId;
        /// <summary>
        /// Determinates if the user has the specified role.
        /// </summary>
        public bool HasRole { get; set; } = hasRole;
    }
}
