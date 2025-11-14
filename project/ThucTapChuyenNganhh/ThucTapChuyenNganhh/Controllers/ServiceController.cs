using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenNganhh.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
