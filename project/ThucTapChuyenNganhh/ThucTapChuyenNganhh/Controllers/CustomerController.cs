using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenNganhh.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
