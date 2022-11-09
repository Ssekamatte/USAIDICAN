using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewOnaBspsurveyRevised
    {
        public double Id { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Village { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int? Sex { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
    }
}
