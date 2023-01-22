namespace LeaderBoards.Models
{
    public class Leader
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Points { get; set; }
        public string? Email { get; set; }
        public string? ImgUrl { get; set; }

        public string? Description { get; set; }

        public bool IsAdmin { get; set; } 
    }
}
