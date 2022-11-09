using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaCommunityTeamRegister
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string Endd { get; set; }
        public string Deviceid { get; set; }
        public string District { get; set; }
        public string Dcode { get; set; }
        public string SubCounty { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string VerificationVerifiedby { get; set; }
        public string VerificationTittle { get; set; }
        public DateTime? VerificationVdate { get; set; }
        public string Image { get; set; }
        public string Ack2 { get; set; }
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
        public DateTime? LastUpdatedAt { get; set; }
    }
}
