﻿using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class View2022ParticipationinMiycangroups
    {
        public string LocationGroupid { get; set; }
        public double? MothP19 { get; set; }
        public double? MothPA19 { get; set; }
        public double? MothL19 { get; set; }
        public double? MothLA19 { get; set; }
        public double? OthO19m { get; set; }
        public double? OthO19f { get; set; }
        public double? OthOA19m { get; set; }
        public double? OthOA19f { get; set; }
        public double? Totalfemales { get; set; }
        public double? TotalMales { get; set; }
        public double? GrandTotal { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Village { get; set; }
        public string Region { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int RegionId { get; set; }
        public int DistrictId { get; set; }
    }
}
