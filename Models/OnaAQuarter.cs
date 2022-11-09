using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaAQuarter
    {
        public OnaAQuarter()
        {
            OnaTargets = new HashSet<OnaTargets>();
        }

        public int QuarterId { get; set; }
        public string QuarterDescription { get; set; }

        public virtual ICollection<OnaTargets> OnaTargets { get; set; }
    }
}
