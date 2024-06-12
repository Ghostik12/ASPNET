using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models;
using MVCStartApp.Models.Db;
using System.Diagnostics;

namespace MVCStartApp.Controllers
{
    public class FeedBackController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FeedBack feedBack)
        {
            return StatusCode(200, $"{feedBack.From}, спасибо за отзыв!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
