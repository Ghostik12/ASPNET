using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Repository;

namespace MVCStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public UsersController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _blogRepository.GetUsers();
            return View(users);
        }
    }
}
