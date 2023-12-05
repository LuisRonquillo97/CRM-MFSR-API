namespace CRM_MFSR_API.Models.Dtos.Entities
{
    /// <summary>
    /// Stage Dto.
    /// </summary>
    public class StageDto : BaseEntityDTO
    {
        /// <summary>
        /// Real state development Id.
        /// </summary>
        public Guid DevelopmentId { get; set; }
        /// <summary>
        /// Stage name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Stage description.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Price per square meter.
        /// </summary>
        /// <remarks>This value is used to calculate the lot's price.</remarks>
        public double PricePerSquareMeter { get; set; }
        /// <summary>
        /// Release date for the stage.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// Virtual object development.
        /// </summary>
        public virtual DevelopmentDto? Development { get; set; }
        /// <summary>
        /// Virtual list of lots.
        /// </summary>
        public virtual List<LotDto>? Lots { get; set; }
    }
}
