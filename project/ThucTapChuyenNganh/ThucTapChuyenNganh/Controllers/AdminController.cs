using Microsoft.AspNetCore.Mvc;
using ThucTapChuyenNganh.Models;

namespace ThucTapChuyenNganh.Controllers
{
    public class AdminController : Controller
    {
        private readonly QuanLyCaPheSUContext _db;

        public AdminController(QuanLyCaPheSUContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        public IActionResult Products()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        public IActionResult Orders() => View();
        public IActionResult Customers() => View();
        public IActionResult Reports() => View();
        public IActionResult Login() => View();

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register() => View();
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                TempData["Success"] = "Đã thêm sản phẩm mới thành công!";
                return RedirectToAction("Products");
            }

            return View(model);
        }
        public IActionResult DeleteProduct(int id)
        {
            var p = _db.Products.Find(id);
            if (p == null)
                return NotFound();
            return View(p);
        }

        [HttpPost]
        public IActionResult ProductDelete(int id)
        {
            var p = _db.Products.Find(id);
            if (p != null)
            {
                _db.Products.Remove(p);
                _db.SaveChanges();
                TempData["Success"] = "Xóa sản phẩm thành công!";
            }
            else
            {
                TempData["Error"] = "Không tìm thấy sản phẩm!";
            }
            return RedirectToAction("Products");
        }
        public IActionResult EditProduct(int id)
        {
            var p = _db.Products.Find(id);
            if (p == null)
                return NotFound();
            return View(p);
        }
        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(model);
                _db.SaveChanges();

                TempData["Success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("Products");
            }
            return View(model);
        }
    }
}
