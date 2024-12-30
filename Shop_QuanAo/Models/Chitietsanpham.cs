using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Chitietsanpham
{
    public decimal Idchitietsanpham { get; set; }

    public decimal Idsanpham { get; set; }

    public string? Tenchitiet { get; set; }

    public string? Noidung { get; set; }

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
