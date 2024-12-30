using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Chitietgiohang
{
    public decimal Idchitietgiohang { get; set; }

    public decimal Idgiohang { get; set; }

    public decimal Idsanpham { get; set; }

    public decimal? Soluong { get; set; }

    public virtual Giohang IdgiohangNavigation { get; set; } = null!;

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
