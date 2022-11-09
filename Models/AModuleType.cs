using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AModuleType
    {
        public AModuleType()
        {
            AModule = new HashSet<AModule>();
        }

        public int ModuleTypeId { get; set; }
        public string ModuleTypeName { get; set; }

        public virtual ICollection<AModule> AModule { get; set; }
    }
}
