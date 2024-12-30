using System;
using System.Collections.Generic;

namespace Shop_QuanAo.Models;

public partial class Chatbot
{
    public decimal Idchatbot { get; set; }

    public string? Cauhoi { get; set; }

    public string? Cautraloi { get; set; }

    public string? Danhmuc { get; set; }

    public DateTime Ngaytaocauhoi { get; set; }
}
