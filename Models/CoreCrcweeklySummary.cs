using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class CoreCrcweeklySummary
    {
        public int WeeklySummaryId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string DeviceId { get; set; }
        public int? District { get; set; }
        public int? County { get; set; }
        public int? SubCounty { get; set; }
        public int? Village { get; set; }
        public int? School { get; set; }
        public string SchoolName { get; set; }
        public string ClubName { get; set; }
        public int? FieldOfficer { get; set; }
        public string CalcYr { get; set; }
        public string CurrYr { get; set; }
        public string CurrMth { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Patron { get; set; }
        public int? Topic { get; set; }
        public int? Gender { get; set; }
        public byte[] Image { get; set; }
        public string Comments { get; set; }
        public string Acknowledge { get; set; }
        public string InstanceId { get; set; }
        public int? Id { get; set; }
        public int? Uuid { get; set; }
        public DateTime? Submissiontime { get; set; }
        public string Iindenx { get; set; }
        public string Parenttablename { get; set; }
        public string Parentindex { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public string Version { get; set; }
        public DateTime? Duration { get; set; }
        public string SubmittedBy { get; set; }
        public int? XformId { get; set; }

        public virtual ACounty CountyNavigation { get; set; }
        public virtual AFieldOfficer FieldOfficerNavigation { get; set; }
        public virtual AGender GenderNavigation { get; set; }
        public virtual AMonth MonthNavigation { get; set; }
        public virtual AGroupId SchoolNavigation { get; set; }
        public virtual ATopic TopicNavigation { get; set; }
        public virtual AYear YearNavigation { get; set; }
    }
}
