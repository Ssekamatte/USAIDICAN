using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class Onauku
    {
        public double Id { get; set; }
        public string Endd { get; set; }
        public string Fieldteam { get; set; }
        public string Start { get; set; }
        public string Deviceid { get; set; }
        public string LocRegion { get; set; }
        public string LocDistrict { get; set; }
        public string LocSubcounty { get; set; }
        public string LocParish { get; set; }
        public string Loc { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string School { get; set; }
        public string Patron { get; set; }
        public string Topic { get; set; }
        public string Theme1 { get; set; }
        public double? Boys { get; set; }
        public string Theme2 { get; set; }
        public string Theme3 { get; set; }
        public double? Girls { get; set; }
        public string Comments { get; set; }
        public string Gps { get; set; }
        public double? GpsLatitude { get; set; }
        public double? GpsLongitude { get; set; }
        public double? GpsAltitude { get; set; }
        public double? GpsPrecision { get; set; }
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
    }
}
