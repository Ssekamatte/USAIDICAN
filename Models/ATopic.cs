using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ATopic
    {
        public ATopic()
        {
            CoreCrcweeklySummary = new HashSet<CoreCrcweeklySummary>();
        }

        public int TopicId { get; set; }
        public string TopicName { get; set; }

        public virtual ICollection<CoreCrcweeklySummary> CoreCrcweeklySummary { get; set; }
    }
}
