using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ABspSurveyfinalacty
    {
        public ABspSurveyfinalacty()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
        }

        public int ActivitiesId { get; set; }
        public string ActivityName { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
    }
}
