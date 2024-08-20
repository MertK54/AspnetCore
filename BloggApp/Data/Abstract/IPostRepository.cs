using BloggApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
        void CreatePost(Post post);
        void EditPost(Post post);
        void DeletePost(Post post);
        void EditPost(Post post, int[] tagIds);
    }
}