using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ARegions
    {
        public ARegions()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public string LocRegion { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
