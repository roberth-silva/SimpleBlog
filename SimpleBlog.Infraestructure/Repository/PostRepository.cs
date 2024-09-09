using SimpleBlog.Infraestructure.Data;
using SimpleBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Infraestructure.Repository
{
    public class PostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<PostModel>> ListPosts()
        {
            var result = await _context.Posts.Include(u => u.User).ToListAsync();
            return result;
        }
        public async Task<PostModel> GetPost(int? id)
        {
            var post = await _context.Posts.Include(p => p.User).FirstOrDefaultAsync(m => m.Id == id);
            return post;
        }
        public async Task<int> InsertPost(PostModel post)
        {
            _context.Add(post);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        public async Task<int> EditPost(PostModel post)
        {
            _context.Update(post);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        public async Task<int> DeletePost(PostModel post)
        {
            _context.Remove(post);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        public bool PostExists(int id)
        {
            var result = _context.Posts.Any(e => e.Id == id);
            return result;
        }
    }
}
