using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AGroupId
    {
        public AGroupId()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
            CoreCrcweeklySummary = new HashSet<CoreCrcweeklySummary>();
            CoreMiycanmonthlySummary = new HashSet<CoreMiycanmonthlySummary>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
        public virtual ICollection<CoreCrcweeklySummary> CoreCrcweeklySummary { get; set; }
        public virtual ICollection<CoreMiycanmonthlySummary> CoreMiycanmonthlySummary { get; set; }
    }
}
