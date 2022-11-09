using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewOnaIcanpopulation
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
        public double? Athousanddays { get; set; }
        public double? Popn1564yrs { get; set; }
        public double? PopnWcba { get; set; }
        public double? Cwr { get; set; }
        public double? Threehhds { get; set; }
        public double? Percentagelessthan5yr { get; set; }
        public double? PercentageWcba { get; set; }
        public double? Percentage1565yr { get; set; }
        public int? RegionId { get; set; }
        public int? DistrictId { get; set; }
        public double? Percentagepregnantlactating { get; set; }
        public DateTime? LastUploadDate { get; set; }
    }
}
