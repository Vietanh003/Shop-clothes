using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Chitietdonhang
{
    public decimal Idchitietdonhang { get; set; }

    public decimal Iddonhang { get; set; }

    public decimal Idsanpham { get; set; }

    public decimal? Soluong { get; set; }

    public virtual Donhang IddonhangNavigation { get; set; } = null!;

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
