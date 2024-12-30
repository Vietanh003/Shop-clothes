using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Loaisanpham
{
    public decimal Idloaisanpham { get; set; }

    public decimal Iddanhmuc { get; set; }

    public string Tenloaisanpham { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual Danhmuc IddanhmucNavigation { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
