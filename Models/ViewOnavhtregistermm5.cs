using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewOnavhtregistermm5
    {
        public int Id { get; set; }
        public string Mm5Preg { get; set; }
        public string Mm5MFname { get; set; }
        public string Mm5MLastname { get; set; }
        public string VhtFname { get; set; }
        public string VhtLname { get; set; }
        public string LocRegion { get; set; }
        public string LocDistrict { get; set; }
        public string LocSubcounty { get; set; }
        public string LocParish { get; set; }
        public string Loc { get; set; }
        public DateTime? SubmissionTime { get; set; }
    }
}
