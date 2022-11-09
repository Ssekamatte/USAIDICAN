using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewMiycanptasSmcsSupportedByIcan
    {
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
        public string Village { get; set; }
        public int? Event { get; set; }
        public int? Meeting { get; set; }
        public string Males { get; set; }
        public string Females { get; set; }
        public int? EventYear { get; set; }
        public int? EventMonth { get; set; }
        public int? NumberPtasmc { get; set; }
        public int? MonthId { get; set; }
        public string MonthName { get; set; }
    }
}
