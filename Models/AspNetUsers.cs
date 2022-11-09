using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string NameOfUserAccountHolder { get; set; }
        public int? Department { get; set; }
        public int? Organization { get; set; }
        public int? RegionId { get; set; }
        public int? DistrictId { get; set; }
        public bool? Deleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string RetrievedBy { get; set; }
        public DateTime? RetrievedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime? RegisteredDate { get; set; }

        public virtual ADistricts District { get; set; }
        public virtual ARegions Region { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
    }
}
