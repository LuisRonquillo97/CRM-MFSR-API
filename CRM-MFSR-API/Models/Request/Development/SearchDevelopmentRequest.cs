using CRM_MFSR_API.Models.Dtos.Entities;

namespace CRM_MFSR_API.Models.Request.Development
{
    /// <summary>
    /// Request to search developments.
    /// </summary>
    public class SearchDevelopmentRequest
    {
        /// <summary>
        /// Development name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Development description.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Start date for release of the development.
        /// </summary>
        public DateTime? StartDate { get; set; }
        
        /// <summary>
        /// End date for release of the development.
        /// </summary>
        public DateTime? EndDate { get; set; }
        
        /// <summary>
        /// Transform this request to DevelopmentDto.
        /// </summary>
        /// <returns></returns>
        public DevelopmentDto ToDevelopmentDto()
        {
            return new DevelopmentDto
            {
                Name = Name,
                Description = Description,
            };
        }
    }
}
