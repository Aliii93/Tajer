using System;
using System.Collections.Generic;

namespace TajerTest.Models
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
