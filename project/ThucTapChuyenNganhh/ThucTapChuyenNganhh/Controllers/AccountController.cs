using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenNganhh.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return RedirectToAction("Index", "Admin");
        }


        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}

