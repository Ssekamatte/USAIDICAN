﻿using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class View2022ParticipationinProductionorsavinggroups
    {
        public string LocationGroupid { get; set; }
        public double? NumbersMaleY { get; set; }
        public double? NumbersMaleA { get; set; }
        public double? NumbersFemaleY { get; set; }
        public double? NumbersFemaleA { get; set; }
        public double? TotalMales { get; set; }
        public double? TotalFemales { get; set; }
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
