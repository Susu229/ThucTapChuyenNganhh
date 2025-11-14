using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ThucTapChuyenNganhh.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        [Display(Name = "Mã SP")]

        public string Code { get; set; } = "";
        [Required, StringLength(120)]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; } = "";

        [Range(0, 999_999_999)]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Tình trạng")]
        public string Status { get; set; } = "Còn hàng";
    }
}
