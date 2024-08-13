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
        private readonly ITagRepository _tagRepository;

        public HomeController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_tagRepository.Tags.ToList());
        }
    }
}