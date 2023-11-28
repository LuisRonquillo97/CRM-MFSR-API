using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    /// <summary>
    /// Role permissions.
    /// </summary>
    public class RolePermission : BaseAttributes
    {
        /// <summary>
        /// Role Id.
        /// </summary>
        public Guid RoleId { get; set; }
        /// <summary>
        /// Permission Id.
        /// </summary>
        public Guid PermissionId { get; set; }
        /// <summary>
        /// Virtual object Role.
        /// </summary>
        public virtual Role? Role { get; set; }
        /// <summary>
        /// Virtual object Permission.
        /// </summary>
        public virtual Permission? Permission { get; set; }
    }
}
