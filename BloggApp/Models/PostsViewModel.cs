using BloggApp.Entity;

namespace BloggApp.Models
{
    public class PostsViewModel
    {
        public List<Post> Posts { get; set; } = new();
    }
}