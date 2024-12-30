using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Donhang
{
    public decimal Iddonhang { get; set; }

    public decimal Idkhachhang { get; set; }

    public decimal? Idnhanvien { get; set; }

    public decimal? Idgiamgia { get; set; }

    public DateTime Ngaytao { get; set; }

    public DateTime? Ngaygiaohang { get; set; }

    public string Diachi { get; set; } = null!;

    public decimal? Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Giamgium? IdgiamgiaNavigation { get; set; }

    public virtual Nhanvien? IdnhanvienNavigation { get; set; }

    public virtual ICollection<Thanhtoan> Thanhtoans { get; set; } = new List<Thanhtoan>();
}
