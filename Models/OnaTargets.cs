using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaTargets
    {
        public int TargetId { get; set; }
        public string Indicator { get; set; }
        public int? IndicatorId { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public int? Target { get; set; }
        public int? Actual { get; set; }
        public int? Year { get; set; }
        public int? FinancialYearId { get; set; }
        public int? QuarterId { get; set; }
        public double? Quarter1 { get; set; }
        public double? Quarter2 { get; set; }
        public double? Quarter3 { get; set; }
        public double? Quarter4 { get; set; }
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
        public string AddedBy { get; set; }
        public DateTime? AddedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual OnaAFinancialYears FinancialYear { get; set; }
        public virtual OnaATargets IndicatorNavigation { get; set; }
        public virtual OnaAQuarter Quarter { get; set; }
        public virtual AYear YearNavigation { get; set; }
    }
}
