using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ABspSurveyfinalnut
    {
        public ABspSurveyfinalnut()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
        }

        public int NutritionId { get; set; }
        public string NutritionName { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
    }
}
