using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkApp.Models;

namespace EntityFrameworkApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
