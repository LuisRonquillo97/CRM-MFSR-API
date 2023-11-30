using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Dtos.Entities
{
    /// <summary>
    /// Lot category dto.
    /// </summary>
    public class LotCategoryDto : BaseEntityDTO
    {
        /// <summary>
        /// Category name.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Category description.
        /// </summary>
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Virtual object lot.
        /// </summary>
        public virtual List<LotDto>? Lots { get; set; }
    }
}
