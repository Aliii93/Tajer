using System;
using System.Collections.Generic;

namespace TajerTest.Models
{
    public partial class PermissionRole
    {
        public int? PermissonId { get; set; }
        public int? RoleId { get; set; }

        public virtual Permission? Permisson { get; set; }
        public virtual Role? Role { get; set; }
    }
}
