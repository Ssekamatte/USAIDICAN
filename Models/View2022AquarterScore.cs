using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class View2022AquarterScore
    {
        public long? RowNumber { get; set; }
        public string LocRegion { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string LocationGroupid { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public double QuarterGrandTotal { get; set; }
        public string QuarterId { get; set; }
    }
}
