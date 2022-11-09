using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewOnaBspsurveyRevisedBackUp
    {
        public double Id { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Village { get; set; }
        public string Mon { get; set; }
        public string Yr { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public string Region { get; set; }
    }
}
