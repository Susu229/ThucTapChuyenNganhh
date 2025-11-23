using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenNganhh.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<object>();
            return View(products);
        }

        public IActionResult Products()
        {
            var products = new List<object>();
            return View(products);
        }

        public IActionResult Orders() => View();
        public IActionResult Customers() => View();
        public IActionResult Reports() => View();
        public IActionResult Login() => View();
        public IActionResult Register() => View();
    }
}
