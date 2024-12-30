using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Danhmuc
{
    public decimal Iddanhmuc { get; set; }

    public string Tendanhmuc { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual ICollection<Loaisanpham> Loaisanphams { get; set; } = new List<Loaisanpham>();
}
