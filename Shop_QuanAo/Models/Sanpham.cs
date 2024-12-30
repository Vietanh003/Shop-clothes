using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Sanpham
{
    public decimal Idsanpham { get; set; }

    public string Tensanpham { get; set; } = null!;

    public decimal Idloaisanpham { get; set; }

    public decimal? Giakhuyenmai { get; set; }

    public decimal? Giagoc { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

    public virtual ICollection<Chitietkhuyenmai> Chitietkhuyenmais { get; set; } = new List<Chitietkhuyenmai>();

    public virtual ICollection<Chitietsanpham> Chitietsanphams { get; set; } = new List<Chitietsanpham>();

    public virtual ICollection<Hinhanh> Hinhanhs { get; set; } = new List<Hinhanh>();

    public virtual Loaisanpham IdloaisanphamNavigation { get; set; } = null!;

    public virtual ICollection<Kichthuocsanpham> Kichthuocsanphams { get; set; } = new List<Kichthuocsanpham>();

    public virtual ICollection<Mausacsanpham> Mausacsanphams { get; set; } = new List<Mausacsanpham>();

    public virtual ICollection<Tonkho> Tonkhos { get; set; } = new List<Tonkho>();

    public virtual ICollection<Yeuthich> Yeuthiches { get; set; } = new List<Yeuthich>();
}
