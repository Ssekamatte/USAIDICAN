using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class View2022OnaTargetsUpdated
    {
        public string Region { get; set; }
        public string District { get; set; }
        public int? Target { get; set; }
        public int? Actual { get; set; }
        public int? Year { get; set; }
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
        public string Duration { get; set; }
        public string SubmittedBy { get; set; }
        public double? XformId { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string DistrictDescription { get; set; }
        public int DistrictId { get; set; }
        public string RegionDescription { get; set; }
        public int RegionId { get; set; }
        public int? FinancialYearId { get; set; }
        public string FinancialYearDesc { get; set; }
        public int? QuarterId { get; set; }
        public string QuarterDescription { get; set; }
        public int? IndicatorId { get; set; }
        public int TargetId { get; set; }
        public string IndicatorDescription { get; set; }
        public double Quarter1 { get; set; }
        public double Quarter2 { get; set; }
        public double Quarter3 { get; set; }
        public double Quarter4 { get; set; }
        public double QuarterActualTotal { get; set; }
        public double PercentageAchievement { get; set; }
        public string Subcounty { get; set; }
        public int? SubcountyId { get; set; }
    }
}
