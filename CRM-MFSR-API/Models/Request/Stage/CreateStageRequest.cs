using CRM_MFSR_API.Models.Dtos.Entities;
using System.Reflection.Metadata.Ecma335;

namespace CRM_MFSR_API.Models.Request.Stage
{
    /// <summary>
    /// Create stage request
    /// </summary>
    public class CreateStageRequest
    {
        /// <summary>
        /// Stage name.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Stage description.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Release date of stage.
        /// </summary>
        public required DateTime ReleaseDate { get; set; }
        /// <summary>
        /// Price per square meter
        /// </summary>
        public required double PricePerSquareMeter { get; set; }
        /// <summary>
        /// Owner development id.
        /// </summary>
        public required Guid DevelopmentId { get; set; }
        /// <summary>
        /// Person who creates the record.
        /// </summary>
        public required string CreatedBy { get; set; }
        /// <summary>
        /// Convert this request to StageDto.
        /// </summary>
        /// <returns></returns>
        public StageDto ToStageDto()
        {
            return new StageDto
            {
                Name = Name,
                Description = Description,
                ReleaseDate = ReleaseDate,
                PricePerSquareMeter = PricePerSquareMeter,
                DevelopmentId = DevelopmentId,
                CreatedBy = CreatedBy,
                CreatedAt = DateTime.Now
            };
        }
    }
}
