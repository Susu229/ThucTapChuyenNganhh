using ThucTapChuyenNganhh.Data;
using ThucTapChuyenNganhh.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("KoppeeDB"));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new Product { Code = "CF001", Name = "Espresso", Price = 35000, Status = "Còn hàng" },
            new Product { Code = "CF002", Name = "Latte", Price = 42000, Status = "Sắp hết" },
            new Product { Code = "CF003", Name = "Mocha", Price = 45000, Status = "Hết hàng" }
        );

        db.SaveChanges();
    }
}


app.Run();


app.UseStaticFiles();
