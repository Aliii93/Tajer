using System;
using System.Collections.Generic;

namespace TajerTest.Models
{
    public partial class Item
    {
        public Guid ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDesc { get; set; }
        public DateTime? ItemDate { get; set; }
        public double? Price { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
