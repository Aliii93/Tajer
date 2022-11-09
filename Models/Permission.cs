using System;
using System.Collections.Generic;

namespace TajerTest.Models
{
    public partial class Permission
    {
        public int PemissionId { get; set; }
        public string? PermissionName { get; set; }
        public string? PermissionDesc { get; set; }
    }
}
