using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewUsersRoles
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string NameOfUserAccountHolder { get; set; }
        public bool? Deleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string RetrievedBy { get; set; }
        public DateTime? RetrievedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public int? Department { get; set; }
        public int? Organization { get; set; }
        public string PhoneNumber { get; set; }
    }
}
