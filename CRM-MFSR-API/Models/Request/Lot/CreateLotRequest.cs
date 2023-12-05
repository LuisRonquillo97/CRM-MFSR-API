using CRM_MFSR_API.Models.Dtos.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Request.Lot
{
    /// <summary>
    /// Request to create a new lot.
    /// </summary>
    public class CreateLotRequest
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
        /// Lot front meters.
        /// </summary>
        public double FrontMeters { get; set; }

        /// <summary>
        /// Lot bottom meters
        /// </summary>
        public double BottomMeters { get; set; }

        /// <summary>
        /// Original pricer per square meter used to calculate the price.
        /// </summary>
        public double PricePerSquareMeterUsed { get; set; }

        /// <summary>
        /// Lot category Id.
        /// </summary>
        public Guid LotCategoryId { get; set; }

        /// <summary>
        /// Person who creates the record.
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Convert this request into a LotDto.
        /// </summary>
        /// <returns>LotDto.</returns>
        public LotDto ToLotDto()
        {
            return new LotDto
            {
                StageId = StageId,
                Name = Name,
                FrontMeters = FrontMeters,
                BottomMeters = BottomMeters,
                PricePerSquareMeterUsed = PricePerSquareMeterUsed,
                LotCategoryId = LotCategoryId,
                CreatedAt = DateTime.Now,
                CreatedBy = CreatedBy
            };
        }
    }
}
