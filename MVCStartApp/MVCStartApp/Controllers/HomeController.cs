using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models;
using MVCStartApp.Repository;
using System.Diagnostics;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogRepository _blogRepository;

        public HomeController(ILogger<HomeController> logger, IBlogRepository blogRepository)
        {
            _logger = logger;
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Nasty",
                LastName = "Lu",
                JoinDate = DateTime.Now
            };

            await _blogRepository.AddUser(newUser);

            Console.WriteLine($"User with id {newUser.Id}, name {newUser.FirstName} join at {newUser.JoinDate}");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Authors()
        {
            var authors = await _blogRepository.GetUsers();
            return View(authors);
        }
    }
}
