using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewWomenofReproductiveAge
    {
        public double? MothL19 { get; set; }
        public double? MothP19 { get; set; }
        public double? MothPA19 { get; set; }
        public double? MothLA19 { get; set; }
        public double? OthO19f { get; set; }
        public double? OthO19m { get; set; }
        public double? OthOA19m { get; set; }
        public double? OthOA19f { get; set; }
        public double WomenNumber { get; set; }
        public string LocationGroupid { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Region { get; set; }
    }
}
