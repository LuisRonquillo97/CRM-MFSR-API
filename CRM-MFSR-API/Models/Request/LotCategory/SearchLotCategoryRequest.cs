using CRM_MFSR_API.Models.Dtos.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Request.LotCategory
{
    /// <summary>
    /// Request to search lot categories.
    /// </summary>
    public class SearchLotCategoryRequest
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
        /// Convert this into LotCategoryDto.
        /// </summary>
        /// <returns>LotCategoryDto.</returns>
        public LotCategoryDto ToLotCategoryDto()
        {
            return new LotCategoryDto() { 
                Name = Name, 
                Description = Description 
            };
        }
    }
}
