using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewReproductiveAgeinIcangroups
    {
        public string LocationGroupid { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public double? FemaleYouths { get; set; }
        public double? FemaleAdults { get; set; }
        public string Region { get; set; }
    }
}
