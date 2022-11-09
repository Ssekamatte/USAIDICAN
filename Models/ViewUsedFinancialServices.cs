using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewUsedFinancialServices
    {
        public double Id { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public double? QnIntroMaleyouth { get; set; }
        public double? QnIntroFemaleyouth { get; set; }
        public double? QnIntroMaleadults { get; set; }
        public double? QnIntroFemaleadults { get; set; }
        public string D13 { get; set; }
        public int? SubmissionYear { get; set; }
        public int? SubmissionMonth { get; set; }
        public int? TotalfinancialServices { get; set; }
        public int? MonthId { get; set; }
        public string MonthName { get; set; }
    }
}
