using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewGroupsReachedDiss
    {
        public double Id { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public int? SubmissionYear { get; set; }
        public string MonthName { get; set; }
    }
}
