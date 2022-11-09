using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewMiycanbeneficiarieDistSubTotal
    {
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Yearr { get; set; }
        public string Monthh { get; set; }
        public double? TotalBeneficiaries { get; set; }
    }
}
