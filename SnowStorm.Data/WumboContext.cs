using Microsoft.EntityFrameworkCore;
using SnowStorm.Models;

namespace WumboBackend.Data
{
    public class WumboContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public WumboContext(DbContextOptions<WumboContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Replies)
                .WithOne(r => r.Post)
                .HasForeignKey(r => r.PostId);
        }
    }
}
