using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaEreProfiling
    {
        public double Id { get; set; }
        public DateTime? VisitDate { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
        public string Village { get; set; }
        public string Fo { get; set; }
        public string CellId { get; set; }
        public string Ere { get; set; }
        public string EreNum { get; set; }
        public string EreId { get; set; }
        public double? NumHhs { get; set; }
        public string Villageleader { get; set; }
        public string Sex { get; set; }
        public string Phonecontact { get; set; }
        public string MothersPregless19 { get; set; }
        public string MothersPreg19plus { get; set; }
        public string MothersLacless19 { get; set; }
        public string MothersLac19plus { get; set; }
        public string MothersOtherless19f { get; set; }
        public string MothersOther19plusf { get; set; }
        public string MothersOtherless19m { get; set; }
        public string MothersOther19plusm { get; set; }
        public string MothersNumunder5 { get; set; }
        public string MothersNumunder2 { get; set; }
        public string Gps { get; set; }
        public double? GpsLatitude { get; set; }
        public double? GpsLongitude { get; set; }
        public double? GpsAltitude { get; set; }
        public double? GpsPrecision { get; set; }
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
    }
}
