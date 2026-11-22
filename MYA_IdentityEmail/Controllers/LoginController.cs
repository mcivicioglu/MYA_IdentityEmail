using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MYA_IdentityEmail.Entities;
using MYA_IdentityEmail.Models;
using System.Text.RegularExpressions;

namespace MYA_IdentityEmail.Controllers
{
    public class LoginController : Controller
    {
        private const string InvalidLoginMessage = "Giriş bilgileri hatalı.";
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private async Task<AppUser?> FindUserAsync(string login)
        {

            if (string.IsNullOrWhiteSpace(login))
            {
                return null;
            }

            login = login.Trim();
            if (login.Contains("@"))
            {
                return await _userManager.FindByEmailAsync(login);
            }
            // TODO: telefon normalize + PhoneNumber ile arama
            if (Regex.IsMatch(login, @"^\+?[0-9\s\-()]+$"))
            {
                return await _userManager.FindByNameAsync(login);
            }
            return await _userManager.FindByNameAsync(login);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginViewModel);
            }
            var user = await FindUserAsync(userLoginViewModel.Identifier);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, InvalidLoginMessage);
                return View(userLoginViewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(user, userLoginViewModel.Password, userLoginViewModel.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return RedirectToAction("Inbox", "Message");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Hesabınız çok sayıda başarısız giriş nedeniyle geçici olarak kilitlendi.");
            }
            else if (result.IsNotAllowed)
            {
                ModelState.AddModelError(string.Empty, "Giriş yapabilmek için hesabınızı doğrulamanız gerekiyor.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, InvalidLoginMessage);
            }

            return View(userLoginViewModel);
        }

    }
}
