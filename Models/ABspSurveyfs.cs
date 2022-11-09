using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ABspSurveyfs
    {
        public ABspSurveyfs()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
        }

        public int FinancialServiceId { get; set; }
        public string FinancialServiceName { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
    }
}
