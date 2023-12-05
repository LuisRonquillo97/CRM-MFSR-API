using CRM_MFSR_API.Models.Dtos.Entities;

namespace CRM_MFSR_API.Models.Request.Stage
{
    /// <summary>
    /// Request to update stage.
    /// </summary>
    public class UpdateStageRequest
    {
        /// <summary>
        /// Stage id.
        /// </summary>
        public required Guid Id { get; set; }
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
        /// Person who updates the record.
        /// </summary>
        public required string LastUpdatedBy { get; set; }

        /// <summary>
        /// Convert this request to StageDto.
        /// </summary>
        /// <returns></returns>
        public StageDto ToStageDto()
        {
            return new StageDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                ReleaseDate = ReleaseDate,
                PricePerSquareMeter = PricePerSquareMeter,
                DevelopmentId = DevelopmentId,
                LastUpdatedAt = DateTime.Now,
                LastUpdatedBy = LastUpdatedBy
            };
        }
    }
}
