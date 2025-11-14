using Microsoft.EntityFrameworkCore;
using ThucTapChuyenNganhh.Models;

namespace ThucTapChuyenNganhh.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<ContactMess> ContactMesss { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
