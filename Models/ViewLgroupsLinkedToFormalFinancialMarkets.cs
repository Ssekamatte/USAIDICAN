using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewLgroupsLinkedToFormalFinancialMarkets
    {
        public double? Id { get; set; }
        public string Groupid { get; set; }
        public string LocationGroupid { get; set; }
        public string District { get; set; }
        public string GroupName { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
        public string Village { get; set; }
        public int? Acty { get; set; }
        public int? Year { get; set; }
        public string Month { get; set; }
        public string Region { get; set; }
        public double? MaleYouth { get; set; }
        public double? FemaleYouth { get; set; }
        public double? MaleAdults { get; set; }
        public double? FemaleAdults { get; set; }
    }
}
