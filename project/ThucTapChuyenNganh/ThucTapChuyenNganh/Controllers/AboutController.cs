using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucTapChuyenNganh.Models;

namespace ThucTapChuyenNganh.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
