using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewOnaHhprofileFacilitySplitNewRow
    {
        public double Id { get; set; }
        public string Fac { get; set; }
        public string LocDistrict { get; set; }
        public string LocSubcounty { get; set; }
        public string LocParish { get; set; }
        public int? ProfileYear { get; set; }
        public int? ToiletorLatrine { get; set; }
        public int? Washfacility { get; set; }
        public int? Rubbishpit { get; set; }
        public int? None { get; set; }
    }
}
