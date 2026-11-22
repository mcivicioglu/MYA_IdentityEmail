using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MYA_IdentityEmail.Entities;
using MYA_IdentityEmail.Models;

namespace MYA_IdentityEmail.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = userRegisterViewModel.FirstName,
                    LastName = userRegisterViewModel.LastName,
                    UserName = userRegisterViewModel.Username,
                    Email = userRegisterViewModel.Email
                };

                var result = await _userManager.CreateAsync(user, userRegisterViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(userRegisterViewModel);
        }
    }
}
