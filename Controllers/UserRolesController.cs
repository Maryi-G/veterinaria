using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace veterinaria.Controllers
{
    [Authorize]
    public class UserRolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        public async Task<IActionResult> Assign(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            ViewBag.IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Assign(string userId, bool isAdmin)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (isAdmin)
                await _userManager.AddToRoleAsync(user, "Admin");
            else
                await _userManager.RemoveFromRoleAsync(user, "Admin");

            return RedirectToAction(nameof(Index));
        }
    }
}
