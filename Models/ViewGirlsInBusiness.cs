using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewGirlsInBusiness
    {
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Monthh { get; set; }
        public string Yearr { get; set; }
        public string InBusiness { get; set; }
        public string Region { get; set; }
        public int? FamilyBusiness { get; set; }
        public int? FriendBusiness { get; set; }
        public int? AnotherBusiness { get; set; }
    }
}
