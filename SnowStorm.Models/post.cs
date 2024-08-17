namespace SnowStorm.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
