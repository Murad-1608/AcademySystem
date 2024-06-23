using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Models.ViewModels;

namespace StudentManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel viewModel)
        {
            var user = await _userManager.FindByNameAsync(viewModel.UserName);

            if (user == null)
            {
                return View(viewModel);
            }

            var check = await _signInManager.PasswordSignInAsync(user, viewModel.Password, false, false);

            if (check.Succeeded)
                return RedirectToAction("index", "home");

            return View(viewModel);
        }
    }
}
