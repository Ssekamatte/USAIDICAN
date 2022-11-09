using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewGroupsTrainedBusMgt
    {
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Village { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int? Acty { get; set; }
        public int? Tech { get; set; }
        public int? Mgt { get; set; }
        public int? TotalGroupsTrained { get; set; }
        public string Region { get; set; }
        public string TechnologyName { get; set; }
        public string ActivityName { get; set; }
        public string ManagementName { get; set; }
    }
}
