using BloggApp.Data.Abstract;
using BloggApp.Data.Concrete.EfCore;
using BloggApp.Entity;
using BloggApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View(
                new PostsViewModel
                {
                    Posts = _postRepository.Posts.ToList()
                }
            );
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _postRepository.Posts.FirstOrDefaultAsync(p => p.Url == url));
        }
    }
}