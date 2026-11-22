using Microsoft.AspNetCore.Mvc;

namespace MYA_IdentityEmail.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
