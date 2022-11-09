using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ABspSurveygovern
    {
        public ABspSurveygovern()
        {
            CoreCommunityGroupSummary = new HashSet<CoreCommunityGroupSummary>();
        }

        public int GovernId { get; set; }
        public string GovernName { get; set; }

        public virtual ICollection<CoreCommunityGroupSummary> CoreCommunityGroupSummary { get; set; }
    }
}
