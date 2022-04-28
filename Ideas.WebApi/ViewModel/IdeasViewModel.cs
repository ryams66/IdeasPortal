namespace Ideas.WebApi.ViewModel
{
    public class IdeasViewModel
    {
        public int IdeaId { get; set; }
        public DateTime IdeaPosteddate { get; set; }
        public string? IdeaTag { get; set; }
        public string? IdeaMesaage { get; set; }
        public int? IdeaUserid { get; set; }
        public string? IdeaUserName { get; set; }
        public int? liked { get; set; }
    }

    public class UserViewModel
    {
        public int Userid { get; set; }
        public string Username { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
