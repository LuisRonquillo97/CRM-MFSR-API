using CRM_MFSR_API.Models.Dtos.Entities;

namespace CRM_MFSR_API.Models.Request.Stage
{
    /// <summary>
    /// Request to search stages.
    /// </summary>
    public class SearchStageRequest
    {
        /// <summary>
        /// Filter by date. Max date filter.
        /// </summary>
        public DateTime ReleaseDateEnd { get; set; } = DateTime.MaxValue;
        /// <summary>
        /// Filter by date. Min date filter.
        /// </summary>
        public DateTime ReleaseDateStart { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Stage name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Stage description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        public StageDto ToStageDto()
        {
            return new StageDto{
                Name = Name,
                Description = Description
            };
        }
    }
}
