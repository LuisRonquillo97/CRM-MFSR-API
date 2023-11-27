using System.Security.Claims;

namespace CRM_MFSR_API.Models.Dtos.Security
{
    /// <summary>
    /// Token data.
    /// </summary>
    public class TokenData
    {
        /// <summary>
        /// List of claims of the logged user.
        /// </summary>
        public required List<Claim> Claims { get; set; }
        /// <summary>
        /// User name.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Determinates if the user is already authenticated.
        /// </summary>
        public required bool IsAuthenticated { get; set; }
        /// <summary>
        /// If authenticated, obtains what type of authentication the user used.
        /// </summary>
        public required string AuthenticationType { get; set; }
    }
}
