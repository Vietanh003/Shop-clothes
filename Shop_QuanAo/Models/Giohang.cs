using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Giohang
{
    public decimal Idgiohang { get; set; }

    public decimal Idkhachhang { get; set; }

    public decimal? Tongtien { get; set; }

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

    public virtual Khachhang IdkhachhangNavigation { get; set; } = null!;
}
