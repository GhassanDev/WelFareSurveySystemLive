using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WelfareSurveySystem.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }
    }
}
