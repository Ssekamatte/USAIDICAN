using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AVillages
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public string Loc { get; set; }
    }
}
