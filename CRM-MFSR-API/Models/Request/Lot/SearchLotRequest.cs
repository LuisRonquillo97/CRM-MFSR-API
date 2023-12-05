using CRM_MFSR_API.Models.Dtos.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Request.Lot
{
    /// <summary>
    /// Request to search lots.
    /// </summary>
    public class SearchLotRequest
    {
        /// <summary>
        /// Stage Id.
        /// </summary>
        public Guid StageId { get; set; }

        /// <summary>
        /// Lot name.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Lot category Id.
        /// </summary>
        public Guid LotCategoryId { get; set; }

        /// <summary>
        /// Return this into a new LotDto.
        /// </summary>
        /// <returns>LotDto.</returns>
        public LotDto ToLotDto()
        {
            return new LotDto { StageId = StageId, Name = Name, LotCategoryId = LotCategoryId };
        }
    }
}
