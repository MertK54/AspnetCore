using BloggApp.Entity;

namespace BloggApp.Data.Abstract;
public interface ICommentRepository
{
    IQueryable<Comment> Comments { get; }
    void CreateComment(Comment comments);
}