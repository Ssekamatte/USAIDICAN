using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewOnamcgmcgwatt
    {
        public double? Id { get; set; }
        public string WattMStatus { get; set; }
        public string WattFName { get; set; }
        public string WattLName { get; set; }
        public double? WattYob { get; set; }
        public double WattNumUnder5 { get; set; }
        public double WattNumUnder2 { get; set; }
        public string WattGLead { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public string Parish { get; set; }
        public string Village { get; set; }
    }
}
