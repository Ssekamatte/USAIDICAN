using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ACounty
    {
        public ACounty()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
            CoreCrcweeklySummary = new HashSet<CoreCrcweeklySummary>();
            CoreMiycanmonthlySummary = new HashSet<CoreMiycanmonthlySummary>();
        }

        public int CountyId { get; set; }
        public int? DistrictId { get; set; }
        public string CountyName { get; set; }
        public string CountyMinistryCode { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
        public virtual ICollection<CoreCrcweeklySummary> CoreCrcweeklySummary { get; set; }
        public virtual ICollection<CoreMiycanmonthlySummary> CoreMiycanmonthlySummary { get; set; }
    }
}
