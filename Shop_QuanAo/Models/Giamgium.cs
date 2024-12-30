using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Giamgium
{
    public decimal Idgiamgia { get; set; }

    public string Tengiamgia { get; set; } = null!;

    public decimal? Sotiengiam { get; set; }

    public decimal? Phantramgiam { get; set; }

    public decimal? Sotientoida { get; set; }

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();
}
