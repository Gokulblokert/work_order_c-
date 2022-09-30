using System;
using System.Collections.Generic;

namespace workorder.Models
{
    public partial class WorkTb
    {
        public int WorkId { get; set; }
        public string? Place { get; set; }
        public DateTime? DateTime { get; set; }
        public string? TechicianRegisterno { get; set; }
    }
}
