using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ABspSurveyfinalparties
    {
        public ABspSurveyfinalparties()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
        }

        public int PartyId { get; set; }
        public string PartyName { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
    }
}
