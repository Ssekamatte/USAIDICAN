using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewADistricts
    {
        public int DistrictId { get; set; }
        public int RegionId { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
    }
}
