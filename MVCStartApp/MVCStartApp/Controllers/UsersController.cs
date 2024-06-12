using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Repository;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUserRequest _userRequest;

        public UsersController(IBlogRepository blogRepository, IUserRequest userRequest)
        {
            _blogRepository = blogRepository;
            _userRequest = userRequest;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _blogRepository.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _blogRepository.AddUser(newUser);
            return View(newUser);
        }
    }
}
