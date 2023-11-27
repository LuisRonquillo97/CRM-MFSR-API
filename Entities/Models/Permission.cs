namespace Entities.Models
{
    public class Permission : BaseAttributes
    {
        /// <summary>
        /// Owner role Id.
        /// </summary>
        public Guid IdRole { get; set; }
        /// <summary>
        /// Permission internal key.
        /// </summary>
        public string Key { get; set; } = string.Empty;
        /// <summary>
        /// Permission name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Permission description.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Role entity relation.
        /// </summary>
        public virtual Role? Role { get; set; }
    }
}
