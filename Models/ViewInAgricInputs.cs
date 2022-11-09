using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewInAgricInputs
    {
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Village { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int? Sex { get; set; }
        public double? Age { get; set; }
        public double? LinkedToInputMarket { get; set; }
        public double? LinkedToutputMarket { get; set; }
        public double? TotalInputMarkets { get; set; }
        public double? HhsPurchasedAgroInputs { get; set; }
        public double? TotalOutputMarkets { get; set; }
        public double? HhsSoldThroughAnAgent { get; set; }
        public string Region { get; set; }
    }
}
