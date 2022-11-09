using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewBeneficiariesTrainedonFp
    {
        public string LocationGroupid { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Region { get; set; }
        public string Mod { get; set; }
        public double MothL19 { get; set; }
        public double MothP19 { get; set; }
        public double MothPA19 { get; set; }
        public double MothLA19 { get; set; }
        public double OthO19f { get; set; }
        public double OthO19m { get; set; }
        public double OthOA19m { get; set; }
        public double OthOA19f { get; set; }
        public double TotalBeneficiaries { get; set; }
    }
}
