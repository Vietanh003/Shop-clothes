using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Nhanvien
{
    public decimal Idnhanvien { get; set; }

    public string Hotennhanvien { get; set; } = null!;

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public string? Diachinhanvien { get; set; }

    public string? Gmail { get; set; }

    public string? Sodienthoai { get; set; }

    public string? Trangthai { get; set; }

    public DateTime? Ngaytuyendung { get; set; }

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();

    public virtual ICollection<Phieunhap> Phieunhaps { get; set; } = new List<Phieunhap>();

    public virtual ICollection<Tintuc> Tintucs { get; set; } = new List<Tintuc>();
}
