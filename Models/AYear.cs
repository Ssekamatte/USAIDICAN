using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AYear
    {
        public AYear()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
            CoreCrcweeklySummary = new HashSet<CoreCrcweeklySummary>();
            CoreMiycanmonthlySummary = new HashSet<CoreMiycanmonthlySummary>();
            OnaTargets = new HashSet<OnaTargets>();
        }

        public int YearId { get; set; }
        public string YearName { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
        public virtual ICollection<CoreCrcweeklySummary> CoreCrcweeklySummary { get; set; }
        public virtual ICollection<CoreMiycanmonthlySummary> CoreMiycanmonthlySummary { get; set; }
        public virtual ICollection<OnaTargets> OnaTargets { get; set; }
    }
}
