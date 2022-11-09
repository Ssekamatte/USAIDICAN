using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewAParishes
    {
        public int Id { get; set; }
        public int SubCountyId { get; set; }
        public string Parish { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
    }
}
