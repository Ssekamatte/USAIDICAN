using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewLgroups
    {
        public double Id { get; set; }
        public string District { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
        public string Village { get; set; }
        public double? Latitude { get; set; }
        public string LatitudeAltitude { get; set; }
        public double? LatitudeLatitude { get; set; }
        public string LatitudeLongitude { get; set; }
        public string LatitudePrecision { get; set; }
        public double? Longitude { get; set; }
        public double? LongitudeLatitude { get; set; }
        public string LongitudeLongitude { get; set; }
        public string LongitudeAltitude { get; set; }
        public string LongitudePrecision { get; set; }
        public double? MaleYouth { get; set; }
        public double? FemaleYouth { get; set; }
        public double? MaleAdults { get; set; }
        public double? FemaleAdults { get; set; }
        public double? Total { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public int? SubmissionYear { get; set; }
        public string Region { get; set; }
        public string MonthName { get; set; }
        public int? MonthId { get; set; }
    }
}
