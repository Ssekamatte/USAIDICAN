using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class View2022OnaIcanpopulation
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Icansubcounty { get; set; }
        public double? PopnTotalInIcanareas { get; set; }
        public double? PopnFemale { get; set; }
        public double? Popnlessthan1YrNumber { get; set; }
        public double? Popnlessthan5Yrs { get; set; }
        public double? Popnlessthan2Yrs { get; set; }
        public double? Popn1564yrs { get; set; }
        public double? PopnWcda { get; set; }
        public double? AthousandAreas { get; set; }
        public int? RegionId { get; set; }
        public int? DistrictId { get; set; }
        public DateTime? LastUploadDate { get; set; }
        public int? SubcountyId { get; set; }
    }
}
