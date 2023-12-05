using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Developments
{
    /// <summary>
    /// Stage lot.
    /// </summary>
    public class Lot : BaseAttributes
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
        /// Lot area in sqaure meters.
        /// </summary>
        /// <remarks>Cannot set, calculated with front and bottom meters.</remarks>
        public double SquareMetersArea { get => FrontMeters * BottomMeters; }

        /// <summary>
        /// Original pricer per square meter used to calculate the price.
        /// </summary>
        public double PricePerSquareMeterUsed { get; set; }

        /// <summary>
        /// Total price of the lot.
        /// </summary>
        ///<remarks>Cannot set, calculated with SquareMetersArea and PricePerSquareMeterUsed.</remarks>
        public double TotalPrice { get => SquareMetersArea * PricePerSquareMeterUsed; }

        /// <summary>
        /// Lot category Id.
        /// </summary>
        public Guid LotCategoryId { get; set; }
        /// <summary>
        /// Virtual lot category.
        /// </summary>
        public virtual LotCategory? Category { get; set; }

        /// <summary>
        /// Stage.
        /// </summary>
        public virtual Stage? Stage { get; set; }
    }
}
