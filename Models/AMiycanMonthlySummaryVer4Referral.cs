using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AMiycanMonthlySummaryVer4Referral
    {
        public AMiycanMonthlySummaryVer4Referral()
        {
            CoreMiycanmonthlySummary = new HashSet<CoreMiycanmonthlySummary>();
        }

        public int ReferralId { get; set; }
        public string ReferralName { get; set; }

        public virtual ICollection<CoreMiycanmonthlySummary> CoreMiycanmonthlySummary { get; set; }
    }
}
