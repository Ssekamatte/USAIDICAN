using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewFemalessupportedCommGrps
    {
        public string OnGovScheme { get; set; }
        public string MonthName { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
        public int? SubYear { get; set; }
        public int? SubMonth { get; set; }
        public string GovScheme { get; set; }
        public double? TotalGroupMembers { get; set; }
        public double? TotalFemaleMembers { get; set; }
        public double? ProportionWomen { get; set; }
    }
}
