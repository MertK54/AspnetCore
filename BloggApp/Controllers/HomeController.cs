using System.Security.Claims;
using BlogApp.Data.Abstract;
using BloggApp.Data.Abstract;
using BloggApp.Data.Concrete.EfCore;
using BloggApp.Entity;
using BloggApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggApp.Controllers
{
    
    public class HomeController:Controller
    {
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;


        public HomeController(IPostRepository postRepository,ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var postsQuery = _postRepository.Posts
                .Include(p => p.User)
                .Where(i => i.IsActive);

            var posts = await postsQuery.ToListAsync();

            var tags = await _tagRepository.Tags.ToListAsync();

            var viewModel = new IndexViewModel
            {
                Posts = posts,
                Tags = tags
            };
            return View(viewModel);
        }
    }
}