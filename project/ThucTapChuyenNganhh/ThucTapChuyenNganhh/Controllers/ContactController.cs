using Microsoft.AspNetCore.Mvc;
using ThucTapChuyenNganhh.Models;
using ThucTapChuyenNganhh.Data;

namespace ThucTapChuyenNganhh.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;

        public ContactController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Submit(string name, string email, string subject, string message)
        {
            var m = new ContactMess
            {
                Name = name,
                Email = email,
                Subject = subject,
                Message = message
            };

            _db.ContactMesss.Add(m);
            _db.SaveChanges();

            TempData["Success"] = "Gửi tin nhắn thành công!";
            return RedirectToAction("Index");
        }


    }
}
