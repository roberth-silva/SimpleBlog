using Microsoft.AspNetCore.SignalR;
using SimpleBlog.Core.Models;
using SimpleBlog.Infraestructure.Repository;
using SimpleBlog.Services.Data;
using SimpleBlog.Services.Hubs;

namespace SimpleBlog.Infraestructure.Gateway
{    
    public class PostGateway
    {
        PostRepository repository;
        BlogDbContext _context;
        private readonly IHubContext<NotificationHub> _hubContext;
        public PostGateway(BlogDbContext context, IHubContext<NotificationHub> hubContext) 
        {
            _context = context;
            _hubContext = hubContext;
            repository = new PostRepository(_context);
        }

        public async Task<IEnumerable<PostModel>> ListPosts()
        {
            var result = await repository.ListPosts();
            return result;
        }

        public async Task<PostModel> GetPost(int? id)
        {
            var post = await repository.GetPost(id);
            return post;
        }

        public async Task<int> InsertPost(PostModel post)
        {            
            var result = await repository.InsertPost(post);
            return result;
        }
        public async Task<int> EditPost(PostModel post)
        {
            var result = await repository.EditPost(post);
            return result;
        }
        public async Task<int> DeletePost(PostModel post)
        {
            var result = await repository.DeletePost(post);
            return result;
        }
        public bool PostExists(int id)
        {
            var result = repository.PostExists(id);
            return result;
        }
        public async Task NotifyNewPost(PostModel post)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", post.Title, post.Content);
        }
    }    
}
