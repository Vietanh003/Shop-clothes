using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Thanhtoan
{
    public decimal Idthanhtoan { get; set; }

    public decimal Iddonhang { get; set; }

    public string? Phuongthucthanhtoan { get; set; }

    public string? Trangthaithanhtoan { get; set; }

    public DateTime? Ngaythanhtoan { get; set; }

    public string? Magiaodich { get; set; }

    public virtual Donhang IddonhangNavigation { get; set; } = null!;
}
