using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ALoginLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? LoginDate { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string LocDescription { get; set; }
    }
}
