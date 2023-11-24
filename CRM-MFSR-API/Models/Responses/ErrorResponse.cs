namespace CRM_MFSR_API.Models.Responses
{
    /// <summary>
    /// Default generic error response.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Error Message.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
