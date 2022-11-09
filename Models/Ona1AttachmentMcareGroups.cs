using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class Ona1AttachmentMcareGroups
    {
        public int Attachmentid { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Xform { get; set; }
        public string Filename { get; set; }
        public int? Instance { get; set; }
        public string Mimetype { get; set; }
        public string DownloadUrl { get; set; }
        public string SmallDownloadUrl { get; set; }
        public string MediumDownloadUrl { get; set; }
    }
}
