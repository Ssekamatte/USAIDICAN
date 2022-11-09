using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewInSchoolAdolescentsReached
    {
        public string School { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public double Boys { get; set; }
        public double Girls { get; set; }
        public double TotalAdolescents { get; set; }
        public string Region { get; set; }
    }
}
