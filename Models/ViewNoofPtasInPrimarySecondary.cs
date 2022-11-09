using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewNoofPtasInPrimarySecondary
    {
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public int? QnTypestruc { get; set; }
        public int? QnSchooltype { get; set; }
        public int? SubmissionMonth { get; set; }
        public int? SubmissionYear { get; set; }
        public int? MonthId { get; set; }
        public string MonthName { get; set; }
        public string StructureName { get; set; }
        public string SchoolDescription { get; set; }
    }
}
