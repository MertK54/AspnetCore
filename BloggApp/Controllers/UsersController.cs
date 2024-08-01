using BloggApp.Data.Abstract;
using BloggApp.Data.Concrete.EfCore;
using BloggApp.Entity;
using BloggApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggApp.Controllers
{
    public class UsersController : Controller
    {
        public UsersController()
        {

        }
        public IActionResult Login()
        {
            return View();
        }
    }
}