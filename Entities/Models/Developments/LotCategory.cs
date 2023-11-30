using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Developments
{
    /// <summary>
    /// Lot categories.
    /// </summary>
    public class LotCategory : BaseAttributes
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
        /// Virtual object list of lots.
        /// </summary>
        public virtual List<Lot>? Lots { get; set; }
    }
}
