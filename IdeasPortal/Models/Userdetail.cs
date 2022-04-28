using System;
using System.Collections.Generic;

namespace IdeasPortal.Models
{
    public partial class Userdetail
    {
        public Userdetail()
        {
            IdeaBoxes = new HashSet<IdeaBox>();
        }

        public int Userid { get; set; }
        public string Username { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual ICollection<IdeaBox> IdeaBoxes { get; set; }
    }
}
