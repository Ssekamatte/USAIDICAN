using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewIndividualMiycan
    {
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public double? MiycantotalMembers { get; set; }
    }
}
