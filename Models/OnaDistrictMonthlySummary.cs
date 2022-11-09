using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaDistrictMonthlySummary
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string Endd { get; set; }
        public string Deviceid { get; set; }
        public string District { get; set; }
        public string Fyear { get; set; }
        public string Month { get; set; }
        public int? Ddmp { get; set; }
        public int? Sdp { get; set; }
        public int? SchoolsCount { get; set; }
        public double? Vdmp { get; set; }
        public int? VdmpvillagesCount { get; set; }
        public double? Vnrmp { get; set; }
        public int? NrmpvillagesCount { get; set; }
        public int? Pdmp { get; set; }
        public int? ParishesCount { get; set; }
        public int? Sdmp { get; set; }
        public int? SubCountyCount { get; set; }
        public int? FruitTrees { get; set; }
        public int? OtherTrees { get; set; }
        public int? Latrines { get; set; }
        public int? InputAggr { get; set; }
        public int? OutputAggr { get; set; }
        public string Comments { get; set; }
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
