using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewOnaHhprofileFacilitySplitNew
    {
        public double Id { get; set; }
        public int? Fac { get; set; }
        public int ToiletOrLatrine { get; set; }
        public int WashFacility { get; set; }
        public int RubbishPit { get; set; }
        public int None { get; set; }
        public string Description { get; set; }
    }
}
