using Microsoft.AspNetCore.Mvc;

namespace BloggApp.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}