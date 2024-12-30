using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Mausacsanpham
{
    public decimal Idmausac { get; set; }

    public string Tenmau { get; set; } = null!;

    public decimal Idsanpham { get; set; }

    public string? Mota { get; set; }

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
