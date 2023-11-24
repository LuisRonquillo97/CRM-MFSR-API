using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class BaseAttributes
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [MaxLength(250)]
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? LastUpdatedAt { get; set; } = null;
        [MaxLength(250)]
        public string? LastUpdatedBy { get; set; }
        public DateTime? DeactivatedAt { get; set; } = null;
        [MaxLength(250)]
        public string? DeactivatedBy { get; set; }
    }
}
