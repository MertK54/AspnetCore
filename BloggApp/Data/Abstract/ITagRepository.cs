using BloggApp.Entity;

namespace BloggApp.Data.Abstract;
public interface ITagRepository
{
    IQueryable<Tag> Tags { get; }
    void CreateTag(Tag tag);
}