using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Khuyenmai
{
    public decimal Idkhuyenmai { get; set; }

    public string Tenkhuyenmai { get; set; } = null!;

    public DateTime Ngaybatdau { get; set; }

    public DateTime Ngayketthuc { get; set; }

    public DateTime Ngaytao { get; set; }

    public string? Ghichu { get; set; }

    public string? Nguoitao { get; set; }

    public decimal? Phantramkhuyenmai { get; set; }

    public string? Anhkhuyenmai { get; set; }

    public virtual ICollection<Chitietkhuyenmai> Chitietkhuyenmais { get; set; } = new List<Chitietkhuyenmai>();
}
