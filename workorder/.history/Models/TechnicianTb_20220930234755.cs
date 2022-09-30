using System;
using System.Collections.Generic;

namespace workorder.Models
{
    public partial class TechnicianTb
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Status { get; set; }
        /// <summary>
        /// 1 as active,0 as iactive
        /// </summary>
        public string? Registerno { get; set; }
    }
}
