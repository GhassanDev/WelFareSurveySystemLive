using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WelfareSurveySystem.WebUI.Controllers
{
    //[Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            this._userManager = _userManager;
            this._roleManager = _roleManager;
        }
        public IActionResult Index()
        {

            return View(_roleManager.Roles);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            if (_roleManager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                ModelState.AddModelError("", $"Role {role.Name} already exists");
                return View(role);
            }

            _roleManager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();

            TempData["Msg"] = $"Role {role.Name} created successfully";
            return RedirectToAction("Index");
        }
    }
}
