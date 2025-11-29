using Microsoft.AspNetCore.Mvc;
using ThucTapChuyenNganh.Models;

namespace ThucTapChuyenNganh.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
