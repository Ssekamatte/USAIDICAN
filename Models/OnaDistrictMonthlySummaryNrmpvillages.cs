using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class OnaDistrictMonthlySummaryNrmpvillages
    {
        public string UniqueNrmpvillageId { get; set; }
        public string VillageId { get; set; }
        public int? Id { get; set; }
        public string NrmpvillagesNrmpcount { get; set; }
        public string NrmpvillagesVnrmpsubCounty { get; set; }
        public string NrmpvillagesNrmpvillages { get; set; }
        public string Uuid { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public string Index { get; set; }
        public string ParentTableName { get; set; }
        public string ParentIndex { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public string Version { get; set; }
        public string Duration { get; set; }
        public string SubmittedBy { get; set; }
        public string XformId { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
