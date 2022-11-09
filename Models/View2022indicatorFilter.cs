using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class View2022indicatorFilter
    {
        public int? IndicatorId { get; set; }
        public int? FinancialYearId { get; set; }
        public int? QuarterId { get; set; }
        public string IndicatorDescription { get; set; }
        public int? Year { get; set; }
    }
}
