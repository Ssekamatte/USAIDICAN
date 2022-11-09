using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaukuRegisterAttendance
    {
        public string UniqueAttendanceId { get; set; }
        public string AttendanceClass { get; set; }
        public string AttendanceFname { get; set; }
        public string AttendanceLname { get; set; }
        public string AttendanceSex { get; set; }
        public double? AttendanceAge { get; set; }
        public double? Id { get; set; }
        public string Uuid { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public double? Index { get; set; }
        public string ParentTableName { get; set; }
        public double? ParentIndex { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public string Version { get; set; }
        public string Duration { get; set; }
        public string SubmittedBy { get; set; }
        public string XformId { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
