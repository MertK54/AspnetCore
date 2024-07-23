using BloggApp.Data.Abstract;
using BloggApp.Data.Concrete.EfCore;
using BloggApp.Entity;

namespace BloggApp.Data.Concrete
{
    public class EfPostRepositoy : IPostRepository
    {
        private BlogContext _context;
        public EfPostRepositoy(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}