using System.ComponentModel.DataAnnotations;
using BloggApp.Entity;

namespace BloggApp.Models
{
    public class IndexViewModel
{
    public List<Post> Posts { get; set; } = new();
    public List<Tag> Tags { get; set; } = new List<Tag>();
}
}
