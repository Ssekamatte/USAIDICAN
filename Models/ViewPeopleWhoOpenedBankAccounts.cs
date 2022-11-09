using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewPeopleWhoOpenedBankAccounts
    {
        public string LocationGroupid { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Monthh { get; set; }
        public string Yearr { get; set; }
        public string Acty { get; set; }
        public string Tech { get; set; }
        public double NumbersMaleY { get; set; }
        public double NumbersMaleA { get; set; }
        public double NumbersFemaleY { get; set; }
        public double NumbersFemaleA { get; set; }
        public string Region { get; set; }
    }
}
