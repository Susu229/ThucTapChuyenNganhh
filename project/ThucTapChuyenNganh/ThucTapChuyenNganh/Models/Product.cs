using System;
using System.Collections.Generic;

namespace ThucTapChuyenNganh.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public string? Status { get; set; }
}
