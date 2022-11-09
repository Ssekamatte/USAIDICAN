using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class CoreMiycanmonthlySummary
    {
        public int MiycanSummaryId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string DeviceId { get; set; }
        public int? District { get; set; }
        public int? County { get; set; }
        public int? SubCounty { get; set; }
        public int? Village { get; set; }
        public int? GroupId { get; set; }
        public string Groupname { get; set; }
        public int? FieldOfficer { get; set; }
        public string CalcYr { get; set; }
        public string CurrYr { get; set; }
        public string CurrMth { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string VhtFname { get; set; }
        public string VhtLname { get; set; }
        public int? ModuleMod { get; set; }
        public int? Gender { get; set; }
        public int? Age { get; set; }
        public int? Referrals { get; set; }
        public string OtheReferrals { get; set; }
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
        public virtual AGroupId Group { get; set; }
        public virtual AModule ModuleModNavigation { get; set; }
        public virtual AMonth MonthNavigation { get; set; }
        public virtual AMiycanMonthlySummaryVer4Referral ReferralsNavigation { get; set; }
        public virtual AYear YearNavigation { get; set; }
    }
}
