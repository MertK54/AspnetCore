using BloggApp.Data.Abstract;
using BloggApp.Data.Concrete.EfCore;
using BloggApp.Entity;

namespace BloggApp.Data.Concrete
{
    public class EfUserRepositoy : IUserRepository
    {
        private BlogContext _context;
        public EfUserRepositoy(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}