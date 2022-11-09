using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class Onamcg
    {
        public double Id { get; set; }
        public string Endd { get; set; }
        public string Fieldteam { get; set; }
        public string Start { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string LocRegion { get; set; }
        public string LocDistrict { get; set; }
        public string LocSubcounty { get; set; }
        public string LocParish { get; set; }
        public string Loc { get; set; }
        public string OtherSub { get; set; }
        public string OtherParish { get; set; }
        public string Grpname { get; set; }
        public string OtherVillage { get; set; }
        public string Venue { get; set; }
        public string Comments { get; set; }
        public DateTime? DateFormation { get; set; }
        public double? GpsLatitude { get; set; }
        public double? GpsLongitude { get; set; }
        public double? GpsAltitude { get; set; }
        public double? GpsPrecision { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public double? Index { get; set; }
        public string ParentTableName { get; set; }
        public double? ParentIndex { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
