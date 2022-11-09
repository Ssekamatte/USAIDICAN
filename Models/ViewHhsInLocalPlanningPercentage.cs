using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewHhsInLocalPlanningPercentage
    {
        public string District { get; set; }
        public string Subcounty { get; set; }
        public int? Yearr { get; set; }
        public int? Monthh { get; set; }
        public string MonthName { get; set; }
        public decimal? HhsLocalPlanning { get; set; }
        public string Region { get; set; }
    }
}
