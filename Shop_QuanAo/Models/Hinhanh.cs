using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Hinhanh
{
    public decimal Idhinhanh { get; set; }

    public string Url { get; set; } = null!;

    public decimal Idsanpham { get; set; }

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
