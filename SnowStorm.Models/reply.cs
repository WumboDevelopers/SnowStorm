namespace SnowStorm.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign key to the related Post
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
