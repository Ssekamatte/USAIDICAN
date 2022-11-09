using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewApivotTable
    {
        public string LocationGroupid { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string MaleYfemaleY { get; set; }
        public double? Number { get; set; }
    }
}
