using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewARegDisSubParVil
    {
        public int? RegionId { get; set; }
        public string Region { get; set; }
        public int? DistrictId { get; set; }
        public string District { get; set; }
        public int? SubcountyId { get; set; }
        public string Subcounty { get; set; }
        public int? ParishId { get; set; }
        public string Parish { get; set; }
        public int VillageId { get; set; }
        public string Village { get; set; }
    }
}
