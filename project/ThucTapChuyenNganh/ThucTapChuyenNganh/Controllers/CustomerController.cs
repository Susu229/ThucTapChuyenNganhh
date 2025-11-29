using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenNganh.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
