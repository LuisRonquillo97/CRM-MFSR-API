using CRM_MFSR_API.Models.Dtos.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Request.Development
{
    /// <summary>
    /// Request to create a new development.
    /// </summary>
    public class CreateDevelopmentRequest
    {
        /// <summary>
        /// Development name.
        /// </summary>
        [MaxLength(75)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Development description.
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Release date for the development.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Link to OneDrive, Google Drive, or another link to development information.
        /// </summary>
        [MaxLength(500)]
        public string ResourcesUri { get; set; } = string.Empty;

        /// <summary>
        /// Person who creates the record.
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Transform this request into developmentDto
        /// </summary>
        /// <returns></returns>
        public DevelopmentDto ToDevelopmentDto()
        {
            return new DevelopmentDto
            {
                Name = Name,
                Description = Description,
                ReleaseDate = ReleaseDate,
                ResourcesUri = ResourcesUri,
                CreatedBy =  CreatedBy,
                CreatedAt = DateTime.Now
            };
        }
    }
}
