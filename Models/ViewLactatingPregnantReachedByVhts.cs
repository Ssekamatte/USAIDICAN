using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewLactatingPregnantReachedByVhts
    {
        public int PregnantorLactating { get; set; }
        public int ReachedByVhts { get; set; }
        public int? LactatingandPregnantReachedByVhts { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
        public string Village { get; set; }
        public int? SubmissionYear { get; set; }
        public int? SubmissionMonth { get; set; }
        public string MonthName { get; set; }
    }
}
