using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewGeoLocation
    {
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Groupname { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Region { get; set; }
    }
}
