using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ADistricts
    {
        public ADistricts()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string LocDistrict { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
