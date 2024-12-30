using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Chitietkhuyenmai
{
    public decimal Idchitietkhuyenmai { get; set; }

    public decimal Idkhuyenmai { get; set; }

    public decimal Idsanpham { get; set; }

    public virtual Khuyenmai IdkhuyenmaiNavigation { get; set; } = null!;

    public virtual Sanpham IdsanphamNavigation { get; set; } = null!;
}
