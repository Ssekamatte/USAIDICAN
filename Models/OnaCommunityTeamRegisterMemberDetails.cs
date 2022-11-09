using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaCommunityTeamRegisterMemberDetails
    {
        public string MemberDetailsId { get; set; }
        public int? Id { get; set; }
        public string MemberDetailsSerialNo { get; set; }
        public string MemberDetailsName { get; set; }
        public int? MemberDetailsSex { get; set; }
        public double? MemberDetailsAge { get; set; }
        public string MemberDetailsCadre { get; set; }
        public string MemberDetailsRegesteredVht { get; set; }
        public string MemberDetailsMemberId { get; set; }
        public string MemberDetailsTelNumber { get; set; }
        public string MemberDetailsUniqueId { get; set; }
        public string Uuid { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public double? Index { get; set; }
        public string ParentTableName { get; set; }
        public double? ParentIndex { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public string Version { get; set; }
        public string Duration { get; set; }
        public string SubmittedBy { get; set; }
        public string XformId { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
