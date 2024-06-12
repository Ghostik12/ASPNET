using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository;

namespace MVCStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IUserRequest _userRequest;

        public LogsController(IUserRequest userRequest)
        {
            _userRequest = userRequest;
        }
        
        public async Task<IActionResult> Logs()
        {
            var usersLogs = await _userRequest.GetRequests();
            return View(usersLogs);
        }
    }
}
