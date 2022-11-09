using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewOnaUkuRegisterUkuRegisterAttendance
    {
        public double Id { get; set; }
        public string UniqueAttendanceId { get; set; }
        public string AttendanceClass { get; set; }
        public string AttendanceFname { get; set; }
        public string AttendanceLname { get; set; }
        public string AttendanceSex { get; set; }
        public string LocRegion { get; set; }
        public string LocDistrict { get; set; }
        public string LocSubcounty { get; set; }
        public DateTime? ActivityDate { get; set; }
        public double? AttendanceAge { get; set; }
        public string School { get; set; }
        public string Schoolid { get; set; }
    }
}
