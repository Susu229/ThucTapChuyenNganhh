using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenNganhh.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
