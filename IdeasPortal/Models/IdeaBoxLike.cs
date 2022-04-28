using System;
using System.Collections.Generic;

namespace IdeasPortal.Models
{
    public partial class IdeaBoxLike
    {
        public int? IdeaId { get; set; }
        public int? Userid { get; set; }
        public bool? IsLiked { get; set; }

        public virtual IdeaBox? Idea { get; set; }
        public virtual Userdetail? User { get; set; }
    }
}
