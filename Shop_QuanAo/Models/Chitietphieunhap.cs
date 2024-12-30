using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Chitietphieunhap
{
    public decimal Idchitietphieunhap { get; set; }

    public decimal Idphieunhap { get; set; }

    public decimal Idtonkho { get; set; }

    public decimal? Soluongnhap { get; set; }

    public decimal? Dongianhap { get; set; }

    public decimal? Thanhtien { get; set; }

    public virtual Phieunhap IdphieunhapNavigation { get; set; } = null!;

    public virtual Tonkho IdtonkhoNavigation { get; set; } = null!;
}
