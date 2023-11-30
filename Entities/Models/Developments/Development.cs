using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Developments
{
    /// <summary>
    /// Real state developments entity.
    /// </summary>
    public class Development : BaseAttributes
    {
        /// <summary>
        /// Development name.
        /// </summary>
        [MaxLength(75)]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Development description.
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Release date for the development.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// Link to OneDrive, Google Drive, or another link to development information.
        /// </summary>
        [MaxLength(500)]
        public string ResourcesUri { get; set; } = string.Empty;

        /// <summary>
        /// Virtual list of development stages.
        /// </summary>
        public virtual List<Stage>? Stages { get; set; }
    }
}
