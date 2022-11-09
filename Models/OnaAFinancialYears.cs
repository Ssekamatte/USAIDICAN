using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaAFinancialYears
    {
        public OnaAFinancialYears()
        {
            OnaTargets = new HashSet<OnaTargets>();
        }

        public int FinancialYearId { get; set; }
        public string FinancialYearDesc { get; set; }

        public virtual ICollection<OnaTargets> OnaTargets { get; set; }
    }
}
