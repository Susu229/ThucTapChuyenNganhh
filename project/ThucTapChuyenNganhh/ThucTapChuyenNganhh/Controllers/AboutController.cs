using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucTapChuyenNganhh.Models;

namespace ThucTapChuyenNganhh.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
