using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenNganh.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
