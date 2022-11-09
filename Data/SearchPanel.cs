using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USAIDICANBLAZOR.Data
{
    public class SearchPanel
    {
        public string[] Indicator { get; set; }
        public int?[] RegionId { get; set; }
        public int?[] DistrictId { get; set; }
        public int?[] SubcountyId { get; set; }
        public int?[] IndicatorId { get; set; }
        public int?[] FinancialYearId { get; set; }
        public int?[] QuarterId { get; set; }
        public int?[] Year { get; set; }
        public string Response { get; set; }
    }
}
