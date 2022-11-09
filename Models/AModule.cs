using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class AModule
    {
        public AModule()
        {
            CoreMiycanmonthlySummary = new HashSet<CoreMiycanmonthlySummary>();
        }

        public int ModuleId { get; set; }
        public int? ModuleType { get; set; }
        public string ModuleName { get; set; }

        public virtual AModuleType ModuleTypeNavigation { get; set; }
        public virtual ICollection<CoreMiycanmonthlySummary> CoreMiycanmonthlySummary { get; set; }
    }
}
