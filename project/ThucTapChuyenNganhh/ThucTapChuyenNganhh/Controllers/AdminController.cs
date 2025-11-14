using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThucTapChuyenNganhh.Data;
using ThucTapChuyenNganhh.Models;


namespace ThucTapChuyenNganhh.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        public AdminController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _db.Products
                         .OrderByDescending(p => p.Id)
                         .Take(5)
                         .ToListAsync();

            ViewBag.TotalMessages = _db.ContactMesss.Count(); // số tin nhắn

            return View(items); ;
        }
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var items = await _db.Products
                                 .OrderBy(p => p.Code)
                                 .ToListAsync();
            ViewBag.Success = TempData["ok"];
            ViewBag.Error = TempData["err"];
            return View(items);
        }
        public IActionResult Orderss()
        {
            var list = _db.Products.ToList(); 
            return View(list);
        }
        public IActionResult Orders() => View();
        public IActionResult Customers() => View();
        public IActionResult Reports() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product input)
        {
            input.Code = input.Code?.Trim() ?? "";

            var existed = await _db.Products
                                   .FirstOrDefaultAsync(x => x.Code == input.Code);
            if (existed != null)
            {
                ModelState.AddModelError("Code",
                    $"Mã {input.Code} đã tồn tại (đang thuộc sản phẩm '{existed.Name}').");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.ShowCreate = true;
                var items = await _db.Products.OrderBy(p => p.Code).ToListAsync();
                return View("Products", items);
            }
            _db.Products.Add(input);
            await _db.SaveChangesAsync();

            TempData["ok"] = "Đã thêm sản phẩm mới.";
            return RedirectToAction(nameof(Products));
        }

        [HttpGet]
        public async Task<IActionResult> CheckCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Json(new { exists = false });

            code = code.Trim();
            var p = await _db.Products.FirstOrDefaultAsync(x => x.Code == code);
            return Json(new { exists = p != null, name = p?.Name ?? "" });
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return PartialView("_EditProductPartial", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(Product input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = await _db.Products.FindAsync(input.Id);
            if (product == null)
            {
                return NotFound();
            }
            product.Code = input.Code.Trim();
            product.Name = input.Name.Trim();
            product.Price = input.Price;
            product.Status = input.Status;

            await _db.SaveChangesAsync();
            TempData["ok"] = $"Đã cập nhật sản phẩm {product.Name}.";
            return RedirectToAction(nameof(Products));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Không tìm thấy sản phẩm cần xóa." });
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = $"Đã xóa sản phẩm '{product.Name}' thành công." });
        }
        public IActionResult Messages()
        {
            var messages = _db.ContactMesss
                              .OrderByDescending(x => x.SentAt)
                              .ToList();
            var list = _db.ContactMesss.OrderByDescending(x => x.SentAt).ToList();
            return View(messages);
        }
        public IActionResult Tasks()
        {
            var list = new List<string>()
                {
                    "Kiểm tra tin nhắn khách hàng",
                    "Xử lý đơn hàng tồn",
                    "Cập nhật menu mới"
                };
            ViewBag.TotalTickets = list.Count;
            return View(list);
        }
        public IActionResult Tickets()
        {
            var list = new List<string>()
            {
                "Hỗ trợ đăng nhập",
                "Khách đặt bàn bị lỗi",
                "Thanh toán không thành công"
            };
            return View(list);
        }
        [HttpPost]
        public IActionResult ReplyMessage(int id, string reply)
        {
            var msg = _db.ContactMesss.Find(id);
            if (msg == null) return NotFound();

            msg.IsReplied = true;
            msg.ReplyMessage = reply;
            _db.SaveChanges();

            TempData["ok"] = "Đã gửi phản hồi cho khách!";
            return RedirectToAction("Messages");
        }


    }
}
