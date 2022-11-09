using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AspNetEmailConfirmationCode
    {
        public double ConfirmationId { get; set; }
        public string UserName { get; set; }
        public string ConfirmationCode { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
    }
}
