using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaATargets
    {
        public OnaATargets()
        {
            OnaTargets = new HashSet<OnaTargets>();
        }

        public int IndicatorId { get; set; }
        public string IndicatorDescription { get; set; }

        public virtual ICollection<OnaTargets> OnaTargets { get; set; }
    }
}
