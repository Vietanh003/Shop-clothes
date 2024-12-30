using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Tintuc
{
    public decimal Idtintuc { get; set; }

    public string Tentintuc { get; set; } = null!;

    public decimal? Idnhanvien { get; set; }

    public DateTime Ngaytao { get; set; }

    public string? Trangthai { get; set; }

    public virtual Nhanvien? IdnhanvienNavigation { get; set; }
}
