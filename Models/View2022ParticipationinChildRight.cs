using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class View2022ParticipationinChildRight
    {
        public string School { get; set; }
        public double? Boys { get; set; }
        public double? Girls { get; set; }
        public double? GrandTotal { get; set; }
        public int Targett { get; set; }
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
