using System.Data;
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            ViewBag.Selams = saat > 12 ? "İyi Günler" : "Günaydın";
            int UserCount = Repository.Users.Where(info => info.WillAttend == true).Count();
            var meetingInfo = new MeetingInfo()
            {
                Id = 1,
                Location = "Sakarya, AVM",
                Date = new DateTime(2024, 06, 20, 20, 0, 0),
                NumberofPeople = UserCount
            };
            return View(meetingInfo);
        }
    }
}