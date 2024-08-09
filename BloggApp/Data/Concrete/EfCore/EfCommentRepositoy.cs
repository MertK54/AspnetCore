using BloggApp.Data.Abstract;
using BloggApp.Data.Concrete.EfCore;
using BloggApp.Entity;

namespace BloggApp.Data.Concrete
{
    public class EfCommentRepositoy : ICommentRepository
    {
        private BlogContext _context;
        public EfCommentRepositoy(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments;

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}