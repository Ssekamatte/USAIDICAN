using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewNumberofschoolsworkingwithIcan
    {
        public double Id { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
        public string Location { get; set; }
        public DateTime? ActivityDate { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public int? Year { get; set; }
        public string Month { get; set; }
    }
}
