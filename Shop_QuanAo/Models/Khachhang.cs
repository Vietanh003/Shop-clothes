using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Khachhang
{
    public decimal Idkhachhang { get; set; }

    public string Hotenkhachhang { get; set; } = null!;

    public string? Diachikhachhang { get; set; }

    public string Sodienthoai { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Khuvuc { get; set; }

    public string? Username { get; set; }

    public string? Passwork { get; set; }

    public virtual ICollection<Giohang> Giohangs { get; set; } = new List<Giohang>();

    public virtual ICollection<Yeuthich> Yeuthiches { get; set; } = new List<Yeuthich>();
}
