using CRM_MFSR_API.Models.Dtos.Entities;

namespace CRM_MFSR_API.Models.Request.Development
{
    /// <summary>
    /// Request to update an existing development.
    /// </summary>
    public class UpdateDevelopmentRequest
    {
        /// <summary>
        /// Development Id.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Development name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Development description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Release date for the development.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Link to OneDrive, Google Drive, or another link to development information.
        /// </summary>
        public string ResourcesUri { get; set; } = string.Empty;

        /// <summary>
        /// Person who creates the record.
        /// </summary>
        public string LastUpdatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Transform this request into developmentDto
        /// </summary>
        /// <returns></returns>
        public DevelopmentDto ToDevelopmentDto()
        {
            return new DevelopmentDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                ReleaseDate = ReleaseDate,
                ResourcesUri = ResourcesUri,
                LastUpdatedBy = LastUpdatedBy,
                LastUpdatedAt = DateTime.Now
            };
        }
    }
}
