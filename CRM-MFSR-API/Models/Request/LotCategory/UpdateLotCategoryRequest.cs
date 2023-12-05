using CRM_MFSR_API.Models.Dtos.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Request.LotCategory
{
    /// <summary>
    /// Request for update a current LotCategory.
    /// </summary>
    public class UpdateLotCategoryRequest
    {
        /// <summary>
        /// Lot category id.
        /// </summary>
        public Guid Id { get; set; }

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
        /// Person who updates the category.
        /// </summary>
        [MaxLength(250)]
        public string LastUpdatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Convert this into a LotCategoryDto.
        /// </summary>
        /// <returns></returns>
        public LotCategoryDto ToLotCategoryDto()
        {
            return new LotCategoryDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                LastUpdatedBy = LastUpdatedBy,
                LastUpdatedAt = DateTime.Now,
            };
        }
    }
}
