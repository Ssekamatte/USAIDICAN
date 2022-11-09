using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class Onamcgwatt
    {
        public string UniqueMcgid { get; set; }
        public double? Id { get; set; }
        public string WattMStatus { get; set; }
        public string WattFName { get; set; }
        public string WattLName { get; set; }
        public double? WattYob { get; set; }
        public double? WattNumUnder5 { get; set; }
        public double? WattNumUnder2 { get; set; }
        public string WattGLead { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
