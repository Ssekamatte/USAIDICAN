using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewMcaregroups
    {
        public double Id { get; set; }
        public int? SubmissionYear { get; set; }
        public string SubmissionMonth { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
        public string Subcounty { get; set; }
        public string Village { get; set; }
        public string Groupid { get; set; }
    }
}
