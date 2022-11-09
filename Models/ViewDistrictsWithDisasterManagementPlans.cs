using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewDistrictsWithDisasterManagementPlans
    {
        public int Id { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Region { get; set; }
        public string Fyear { get; set; }
        public string Month { get; set; }
        public int? Ddmp { get; set; }
    }
}
