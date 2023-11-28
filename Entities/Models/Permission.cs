using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Permission : BaseAttributes
    {
        /// <summary>
        /// Permission internal key.
        /// </summary>
        [MaxLength(50)]
        public string Key { get; set; } = string.Empty;
        /// <summary>
        /// Permission name.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Permission description.
        /// </summary>
        [MaxLength (250)]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Role entity relation.
        /// </summary>
        public virtual List<RolePermission>? RolePermissions { get; set; }
    }
}
