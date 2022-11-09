using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewMeetingOnSchoolAttendance
    {
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Topic { get; set; }
        public string EventMonth { get; set; }
        public int? EventYear { get; set; }
        public int? Males { get; set; }
        public int? Females { get; set; }
    }
}
