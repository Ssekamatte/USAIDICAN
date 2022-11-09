using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USAIDICANBLAZOR.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string AccountHolderName { get; set; }
        public Nullable<double> OperatorId { get; set; }
    }
}
