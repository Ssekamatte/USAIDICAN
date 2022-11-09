using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewIcanbeneficiaries
    {
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
        public int? SubYear { get; set; }
        public int? SubMonth { get; set; }
        public string GroupType { get; set; }
        public double? Maleadults { get; set; }
        public double? Femaleadults { get; set; }
        public double? Maleyouth { get; set; }
        public double? Femaleyouth { get; set; }
        public string GroupName { get; set; }
        public string MonthName { get; set; }
    }
}
