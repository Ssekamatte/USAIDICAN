using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AFieldOfficer
    {
        public AFieldOfficer()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
            CoreCrcweeklySummary = new HashSet<CoreCrcweeklySummary>();
            CoreMiycanmonthlySummary = new HashSet<CoreMiycanmonthlySummary>();
        }

        public int FieldOfficerId { get; set; }
        public string FieldOfficerName { get; set; }
        public int? DistrictId { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
        public virtual ICollection<CoreCrcweeklySummary> CoreCrcweeklySummary { get; set; }
        public virtual ICollection<CoreMiycanmonthlySummary> CoreMiycanmonthlySummary { get; set; }
    }
}
