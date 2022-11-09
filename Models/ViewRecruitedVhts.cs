using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewRecruitedVhts
    {
        public int? Id { get; set; }
        public string District { get; set; }
        public string SubCounty { get; set; }
        public string MemberDetailsCadre { get; set; }
        public string Region { get; set; }
        public int? Year { get; set; }
        public int? MonthId { get; set; }
        public string MonthDesc { get; set; }
    }
}
