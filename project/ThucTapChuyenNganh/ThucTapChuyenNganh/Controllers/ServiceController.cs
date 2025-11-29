using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenNganh.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
