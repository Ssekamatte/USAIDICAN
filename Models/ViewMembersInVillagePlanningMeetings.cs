using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewMembersInVillagePlanningMeetings
    {
        public int? ActivityYear { get; set; }
        public string MonthName { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public int? Event { get; set; }
        public int? Meeting { get; set; }
        public int? Males { get; set; }
        public int? Females { get; set; }
        public int? PlanMeetingsTotalNumber { get; set; }
        public string MeetingName { get; set; }
        public string EventName { get; set; }
    }
}
