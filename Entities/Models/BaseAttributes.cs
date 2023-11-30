using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    /// <summary>
    /// Base Attributes from any entity. used for inheritance.
    /// </summary>
    public class BaseAttributes
    {
        /// <summary>
        /// UUID from the entity.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Determinates if the record is active.
        /// </summary>
        public bool IsActive { get; set; } = true;
        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        /// <summary>
        /// Person who create the record.
        /// </summary>
        [MaxLength(250)]
        public string CreatedBy { get; set; } = string.Empty;
        /// <summary>
        /// If updated, last date when the record was updated.
        /// </summary>
        public DateTime? LastUpdatedAt { get; set; } = null;
        /// <summary>
        /// If updated, last person who updated the record.
        /// </summary>
        [MaxLength(250)]
        public string? LastUpdatedBy { get; set; }
        /// <summary>
        /// If deactivated, deactivated date.
        /// </summary>
        public DateTime? DeactivatedAt { get; set; } = null;
        /// <summary>
        /// If deactivated, person who deactivates the record.
        /// </summary>
        [MaxLength(250)]
        public string? DeactivatedBy { get; set; }
    }
}
