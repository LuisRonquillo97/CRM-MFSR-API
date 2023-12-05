using CRM_MFSR_API.Models.Dtos.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM_MFSR_API.Models.Request.Lot
{
    /// <summary>
    /// Update lot request.
    /// </summary>
    public class UpdateLotRequest
    {
        /// <summary>
        /// Lot ID.
        /// </summary>
        public Guid Id { get; set; }

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
        /// Last updated by.
        /// </summary>
        public string LastUpdatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Convert this into LotDto.
        /// </summary>
        /// <returns></returns>
        public LotDto ToLotDto()
        {
            return new LotDto { 
                Id = Id, 
                StageId = StageId, 
                Name = Name, 
                FrontMeters = FrontMeters, 
                BottomMeters = BottomMeters,
                LastUpdatedAt = DateTime.Now,
                LastUpdatedBy = LastUpdatedBy,
                LotCategoryId = LotCategoryId
            };
        }
    }
}
