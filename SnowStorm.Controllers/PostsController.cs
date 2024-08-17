using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WumboBackend.Data;
using WumboBackend.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace WumboBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly WumboContext _context;

        public PostsController(WumboContext context)
        {
            _context = context;
        }

        // GET: api/posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.Include(p => p.Replies).ToListAsync();
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.Include(p => p.Replies).FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST: api/posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        // POST: api/posts/5/replies
        [HttpPost("{postId}/replies")]
        public async Task<ActionResult<Reply>> PostReply(int postId, Reply reply)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post == null)
            {
                return NotFound();
            }

            reply.PostId = postId;
            _context.Replies.Add(reply);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = postId }, reply);
        }
    }
}
