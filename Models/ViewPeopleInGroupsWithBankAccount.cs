using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewPeopleInGroupsWithBankAccount
    {
        public string Region { get; set; }
        public string LocationGroupid { get; set; }
        public int? BankAccountopenedbygroup { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Monthh { get; set; }
        public string Yearr { get; set; }
        public double NumbersMaleY { get; set; }
        public double NumbersMaleA { get; set; }
        public double NumbersFemaleY { get; set; }
        public double NumbersFemaleA { get; set; }
    }
}
