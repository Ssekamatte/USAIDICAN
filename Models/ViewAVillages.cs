using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewAVillages
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public string Village { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Parish { get; set; }
    }
}
