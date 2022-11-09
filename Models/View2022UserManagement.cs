using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class View2022UserManagement
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string RoleId1 { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string NameOfUserAccountHolder { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool? Deleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string RetrievedBy { get; set; }
        public DateTime? RetrievedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public int? Department { get; set; }
        public int? Organization { get; set; }
        public string NormalizedRoleName { get; set; }
        public int? DistrictId { get; set; }
        public string LocDistrict { get; set; }
        public int? RegionId { get; set; }
        public string LocRegion { get; set; }
    }
}
