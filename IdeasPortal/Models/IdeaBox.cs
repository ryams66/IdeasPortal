using System;
using System.Collections.Generic;

namespace IdeasPortal.Models
{
    public partial class IdeaBox
    {
        public int IdeaId { get; set; }
        public DateTime IdeaPosteddate { get; set; }
        public string? IdeaTag { get; set; }
        public string? IdeaMesaage { get; set; }
        public int? IdeaUserid { get; set; }

        public virtual Userdetail? IdeaUser { get; set; }
    }
}
