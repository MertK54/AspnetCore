using BloggApp.Entity;

namespace BloggApp.Data.Abstract;
public interface IUserRepository
{
    IQueryable<User> Users { get; }
    void CreateUser(User users);
}