using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Phieunhap
{
    public decimal Idphieunhap { get; set; }

    public decimal Idnhanvien { get; set; }

    public DateTime Ngaynhap { get; set; }

    public decimal? Tongtien { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; } = new List<Chitietphieunhap>();

    public virtual Nhanvien IdnhanvienNavigation { get; set; } = null!;
}
