using Ispit.Todo.Models;
using Ispit.Todo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ispit.Todo.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAccountService accountService;


        public HomeController(IAccountService accountService)
        {
           this.accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var profile = await accountService.GetUserProfileAsync(User);
            return View(profile);
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
    }
}
