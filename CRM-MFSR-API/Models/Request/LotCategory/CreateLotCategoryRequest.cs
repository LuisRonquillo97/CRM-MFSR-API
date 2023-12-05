using CRM_MFSR_API.Models.Dtos.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Request.LotCategory
{
    /// <summary>
    /// Request to create a lot category.
    /// </summary>
    public class CreateLotCategoryRequest
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
        /// Person who creates the category.
        /// </summary>
        [MaxLength(250)]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Convert this into a LotCategoryDto.
        /// </summary>
        /// <returns></returns>
        public LotCategoryDto ToLotCategoryDto()
        {
            return new LotCategoryDto
            {
                Name = Name,
                Description = Description,
                CreatedBy = CreatedBy,
                CreatedAt = DateTime.Now,
            };
        }
    }
}
