using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Tonkho
{
    public decimal Idtonkho { get; set; }

    public decimal Idsanpham { get; set; }

    public decimal? Soluongton { get; set; }

    public decimal? Soluongcanhbao { get; set; }

    public virtual ICollection<Chitietphieunhap> Chitietphieunhaps { get; set; } = new List<Chitietphieunhap>();

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
