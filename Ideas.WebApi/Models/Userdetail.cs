using System;
using System.Collections.Generic;

namespace Ideas.WebApi.Models
{
    public partial class Userdetail
    {
        public int Userid { get; set; }
        public string Username { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
