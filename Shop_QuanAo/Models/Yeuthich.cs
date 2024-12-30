using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Yeuthich
{
    public decimal Idyeuthich { get; set; }

    public decimal Idkhachhang { get; set; }

    public decimal Idsanpham { get; set; }

    public virtual Khachhang IdkhachhangNavigation { get; set; } = null!;

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
