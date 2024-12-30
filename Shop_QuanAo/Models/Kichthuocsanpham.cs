using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Kichthuocsanpham
{
    public decimal Idkichthuoc { get; set; }

    public string? Tenkichthuoc { get; set; }

    public decimal Idsanpham { get; set; }

    public string? Mota { get; set; }

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
