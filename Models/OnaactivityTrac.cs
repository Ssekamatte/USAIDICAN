using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaactivityTrac
    {
        public double Id { get; set; }
        public string Start { get; set; }
        public string Endd { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string Deviceid { get; set; }
        public string Fieldteam { get; set; }
        public string LocRegion { get; set; }
        public string LocDistrict { get; set; }
        public string LocSubcounty { get; set; }
        public string LocParish { get; set; }
        public string BenF { get; set; }
        public string Loc { get; set; }
        public string Venue { get; set; }
        public DateTime? ActStart { get; set; }
        public DateTime? ActEnd { get; set; }
        public string Subs { get; set; }
        public string Activity { get; set; }
        public string Descr { get; set; }
        public string Groupid { get; set; }
        public double? MaleY { get; set; }
        public double? MaleA { get; set; }
        public double? FemaleY { get; set; }
        public double? FemaleA { get; set; }
        public string Ack2 { get; set; }
        public string Comments { get; set; }
        public string Image { get; set; }
        public string MetaInstanceId { get; set; }
        public string Uuid { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public double? Index { get; set; }
        public string ParentTableName { get; set; }
        public double? ParentIndex { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public string Version { get; set; }
        public double? Duration { get; set; }
        public string SubmittedBy { get; set; }
        public double? XformId { get; set; }
    }
}
