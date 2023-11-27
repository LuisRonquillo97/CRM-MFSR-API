namespace CRM_MFSR_API.Models.Responses.Security
{
    /// <summary>
    /// Response of User/Login
    /// </summary>
    /// <param name="token">Access token.</param>
    public class LoginResponse(string token)
    {
        /// <summary>
        /// Access token.
        /// </summary>
        public string AccessToken { get; set; } = token;
    }
}
