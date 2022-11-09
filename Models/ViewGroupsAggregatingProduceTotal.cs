using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewGroupsAggregatingProduceTotal
    {
        public int? Id { get; set; }
        public string District { get; set; }
        public string SubCountyDmpsubcounties { get; set; }
        public int InputAggr { get; set; }
        public int OutputAggr { get; set; }
        public string Fyear { get; set; }
        public string Region { get; set; }
    }
}
