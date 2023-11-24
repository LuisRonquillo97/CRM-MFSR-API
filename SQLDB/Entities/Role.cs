﻿using System.ComponentModel.DataAnnotations;

namespace SQLDB.Entities
{
    public class Role : BaseAttributes
    {
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(250)]
        public required string Description { get; set; }
        public virtual List<UserRole>? UserRoles { get; set; }
    }
}
