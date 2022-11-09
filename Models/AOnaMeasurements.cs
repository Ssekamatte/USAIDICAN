using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AOnaMeasurements
    {
        public int MeasurementId { get; set; }
        public string MeasurementDescription { get; set; }
        public double? MeasurementValue { get; set; }
    }
}
