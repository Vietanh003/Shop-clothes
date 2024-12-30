using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Shop_QuanAo.Models;

public partial class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Chatbot> Chatbots { get; set; }

    public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }

    public virtual DbSet<Chitietgiohang> Chitietgiohangs { get; set; }

    public virtual DbSet<Chitietkhuyenmai> Chitietkhuyenmais { get; set; }

    public virtual DbSet<Chitietphieunhap> Chitietphieunhaps { get; set; }

    public virtual DbSet<Chitietsanpham> Chitietsanphams { get; set; }

    public virtual DbSet<Danhmuc> Danhmucs { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Giamgium> Giamgia { get; set; }

    public virtual DbSet<Giohang> Giohangs { get; set; }

    public virtual DbSet<Hinhanh> Hinhanhs { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Khuyenmai> Khuyenmais { get; set; }

    public virtual DbSet<Kichthuocsanpham> Kichthuocsanphams { get; set; }

    public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }

    public virtual DbSet<Mausacsanpham> Mausacsanphams { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phieunhap> Phieunhaps { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Thanhtoan> Thanhtoans { get; set; }

    public virtual DbSet<Tintuc> Tintucs { get; set; }

    public virtual DbSet<Tonkho> Tonkhos { get; set; }

    public virtual DbSet<Yeuthich> Yeuthiches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _configuration.GetConnectionString("OracleDb");
        optionsBuilder.UseOracle(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("BANQUANAO")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Chatbot>(entity =>
        {
            entity.HasKey(e => e.Idchatbot).HasName("SYS_C007582");

            entity.ToTable("CHATBOT");

            entity.Property(e => e.Idchatbot)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDCHATBOT");
            entity.Property(e => e.Cauhoi)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CAUHOI");
            entity.Property(e => e.Cautraloi)
                .HasColumnType("CLOB")
                .HasColumnName("CAUTRALOI");
            entity.Property(e => e.Danhmuc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DANHMUC");
            entity.Property(e => e.Ngaytaocauhoi)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("NGAYTAOCAUHOI");
        });

        modelBuilder.Entity<Chitietdonhang>(entity =>
        {
            entity.HasKey(e => e.Idchitietdonhang).HasName("SYS_C007566");

            entity.ToTable("CHITIETDONHANG");

            entity.Property(e => e.Idchitietdonhang)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDCHITIETDONHANG");
            entity.Property(e => e.Iddonhang)
                .HasColumnType("NUMBER")
                .HasColumnName("IDDONHANG");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");
            entity.Property(e => e.Soluong)
                .HasColumnType("NUMBER")
                .HasColumnName("SOLUONG");

            entity.HasOne(d => d.IddonhangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.Iddonhang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007567");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007568");
        });

        modelBuilder.Entity<Chitietgiohang>(entity =>
        {
            entity.HasKey(e => e.Idchitietgiohang).HasName("SYS_C007598");

            entity.ToTable("CHITIETGIOHANG");

            entity.Property(e => e.Idchitietgiohang)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDCHITIETGIOHANG");
            entity.Property(e => e.Idgiohang)
                .HasColumnType("NUMBER")
                .HasColumnName("IDGIOHANG");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");
            entity.Property(e => e.Soluong)
                .HasColumnType("NUMBER")
                .HasColumnName("SOLUONG");

            entity.HasOne(d => d.IdgiohangNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.Idgiohang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007599");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007600");
        });

        modelBuilder.Entity<Chitietkhuyenmai>(entity =>
        {
            entity.HasKey(e => e.Idchitietkhuyenmai).HasName("SYS_C007515");

            entity.ToTable("CHITIETKHUYENMAI");

            entity.Property(e => e.Idchitietkhuyenmai)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDCHITIETKHUYENMAI");
            entity.Property(e => e.Idkhuyenmai)
                .HasColumnType("NUMBER")
                .HasColumnName("IDKHUYENMAI");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");

            entity.HasOne(d => d.IdkhuyenmaiNavigation).WithMany(p => p.Chitietkhuyenmais)
                .HasForeignKey(d => d.Idkhuyenmai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007516");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Chitietkhuyenmais)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007517");
        });

        modelBuilder.Entity<Chitietphieunhap>(entity =>
        {
            entity.HasKey(e => e.Idchitietphieunhap).HasName("SYS_C007612");

            entity.ToTable("CHITIETPHIEUNHAP");

            entity.Property(e => e.Idchitietphieunhap)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDCHITIETPHIEUNHAP");
            entity.Property(e => e.Dongianhap)
                .HasColumnType("NUMBER")
                .HasColumnName("DONGIANHAP");
            entity.Property(e => e.Idphieunhap)
                .HasColumnType("NUMBER")
                .HasColumnName("IDPHIEUNHAP");
            entity.Property(e => e.Idtonkho)
                .HasColumnType("NUMBER")
                .HasColumnName("IDTONKHO");
            entity.Property(e => e.Soluongnhap)
                .HasColumnType("NUMBER")
                .HasColumnName("SOLUONGNHAP");
            entity.Property(e => e.Thanhtien)
                .HasComputedColumnSql("\"SOLUONGNHAP\"*\"DONGIANHAP\"", false)
                .HasColumnType("NUMBER")
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.IdphieunhapNavigation).WithMany(p => p.Chitietphieunhaps)
                .HasForeignKey(d => d.Idphieunhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007613");

            entity.HasOne(d => d.IdtonkhoNavigation).WithMany(p => p.Chitietphieunhaps)
                .HasForeignKey(d => d.Idtonkho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007614");
        });

        modelBuilder.Entity<Chitietsanpham>(entity =>
        {
            entity.HasKey(e => e.Idchitietsanpham).HasName("SYS_C007486");

            entity.ToTable("CHITIETSANPHAM");

            entity.Property(e => e.Idchitietsanpham)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDCHITIETSANPHAM");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");
            entity.Property(e => e.Noidung)
                .HasColumnType("CLOB")
                .HasColumnName("NOIDUNG");
            entity.Property(e => e.Tenchitiet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENCHITIET");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Chitietsanphams)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007487");
        });

        modelBuilder.Entity<Danhmuc>(entity =>
        {
            entity.HasKey(e => e.Iddanhmuc).HasName("SYS_C007468");

            entity.ToTable("DANHMUC");

            entity.HasIndex(e => e.Tendanhmuc, "SYS_C007469").IsUnique();

            entity.Property(e => e.Iddanhmuc)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDDANHMUC");
            entity.Property(e => e.Mota)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("MOTA");
            entity.Property(e => e.Tendanhmuc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENDANHMUC");
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.Iddonhang).HasName("SYS_C007559");

            entity.ToTable("DONHANG");

            entity.Property(e => e.Iddonhang)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDDONHANG");
            entity.Property(e => e.Diachi)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Idgiamgia)
                .HasColumnType("NUMBER")
                .HasColumnName("IDGIAMGIA");
            entity.Property(e => e.Idkhachhang)
                .HasColumnType("NUMBER")
                .HasColumnName("IDKHACHHANG");
            entity.Property(e => e.Idnhanvien)
                .HasColumnType("NUMBER")
                .HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Ngaygiaohang)
                .HasColumnType("DATE")
                .HasColumnName("NGAYGIAOHANG");
            entity.Property(e => e.Ngaytao)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("NGAYTAO");
            entity.Property(e => e.Tongtien)
                .HasColumnType("NUMBER")
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.IdgiamgiaNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.Idgiamgia)
                .HasConstraintName("SYS_C007561");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.Idnhanvien)
                .HasConstraintName("SYS_C007560");
        });

        modelBuilder.Entity<Giamgium>(entity =>
        {
            entity.HasKey(e => e.Idgiamgia).HasName("SYS_C007551");

            entity.ToTable("GIAMGIA");

            entity.HasIndex(e => e.Tengiamgia, "SYS_C007552").IsUnique();

            entity.Property(e => e.Idgiamgia)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDGIAMGIA");
            entity.Property(e => e.Phantramgiam)
                .HasColumnType("NUMBER")
                .HasColumnName("PHANTRAMGIAM");
            entity.Property(e => e.Sotiengiam)
                .HasColumnType("NUMBER")
                .HasColumnName("SOTIENGIAM");
            entity.Property(e => e.Sotientoida)
                .HasColumnType("NUMBER")
                .HasColumnName("SOTIENTOIDA");
            entity.Property(e => e.Tengiamgia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENGIAMGIA");
        });

        modelBuilder.Entity<Giohang>(entity =>
        {
            entity.HasKey(e => e.Idgiohang).HasName("SYS_C007592");

            entity.ToTable("GIOHANG");

            entity.Property(e => e.Idgiohang)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDGIOHANG");
            entity.Property(e => e.Idkhachhang)
                .HasColumnType("NUMBER")
                .HasColumnName("IDKHACHHANG");
            entity.Property(e => e.Tongtien)
                .HasColumnType("NUMBER")
                .HasColumnName("TONGTIEN");

            entity.HasOne(d => d.IdkhachhangNavigation).WithMany(p => p.Giohangs)
                .HasForeignKey(d => d.Idkhachhang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007593");
        });

        modelBuilder.Entity<Hinhanh>(entity =>
        {
            entity.HasKey(e => e.Idhinhanh).HasName("SYS_C007491");

            entity.ToTable("HINHANH");

            entity.Property(e => e.Idhinhanh)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDHINHANH");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Hinhanhs)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007492");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Idkhachhang).HasName("SYS_C007526");

            entity.ToTable("KHACHHANG");

            entity.HasIndex(e => e.Diachikhachhang, "SYS_C007527").IsUnique();

            entity.HasIndex(e => e.Sodienthoai, "SYS_C007528").IsUnique();

            entity.HasIndex(e => e.Email, "SYS_C007529").IsUnique();

            entity.Property(e => e.Idkhachhang)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDKHACHHANG");
            entity.Property(e => e.Diachikhachhang)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DIACHIKHACHHANG");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Hotenkhachhang)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HOTENKHACHHANG");
            entity.Property(e => e.Khuvuc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("KHUVUC");
            entity.Property(e => e.Passwork)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORK");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SODIENTHOAI");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<Khuyenmai>(entity =>
        {
            entity.HasKey(e => e.Idkhuyenmai).HasName("SYS_C007510");

            entity.ToTable("KHUYENMAI");

            entity.HasIndex(e => e.Tenkhuyenmai, "SYS_C007511").IsUnique();

            entity.Property(e => e.Idkhuyenmai)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDKHUYENMAI");
            entity.Property(e => e.Anhkhuyenmai)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("ANHKHUYENMAI");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Ngaybatdau)
                .HasColumnType("DATE")
                .HasColumnName("NGAYBATDAU");
            entity.Property(e => e.Ngayketthuc)
                .HasColumnType("DATE")
                .HasColumnName("NGAYKETTHUC");
            entity.Property(e => e.Ngaytao)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("NGAYTAO");
            entity.Property(e => e.Nguoitao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NGUOITAO");
            entity.Property(e => e.Phantramkhuyenmai)
                .HasColumnType("NUMBER")
                .HasColumnName("PHANTRAMKHUYENMAI");
            entity.Property(e => e.Tenkhuyenmai)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENKHUYENMAI");
        });

        modelBuilder.Entity<Kichthuocsanpham>(entity =>
        {
            entity.HasKey(e => e.Idkichthuoc).HasName("SYS_C007495");

            entity.ToTable("KICHTHUOCSANPHAM");

            entity.Property(e => e.Idkichthuoc)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDKICHTHUOC");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");
            entity.Property(e => e.Mota)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("MOTA");
            entity.Property(e => e.Tenkichthuoc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENKICHTHUOC");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Kichthuocsanphams)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007496");
        });

        modelBuilder.Entity<Loaisanpham>(entity =>
        {
            entity.HasKey(e => e.Idloaisanpham).HasName("SYS_C007473");

            entity.ToTable("LOAISANPHAM");

            entity.HasIndex(e => e.Tenloaisanpham, "SYS_C007474").IsUnique();

            entity.Property(e => e.Idloaisanpham)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDLOAISANPHAM");
            entity.Property(e => e.Iddanhmuc)
                .HasColumnType("NUMBER")
                .HasColumnName("IDDANHMUC");
            entity.Property(e => e.Mota)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("MOTA");
            entity.Property(e => e.Tenloaisanpham)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENLOAISANPHAM");

            entity.HasOne(d => d.IddanhmucNavigation).WithMany(p => p.Loaisanphams)
                .HasForeignKey(d => d.Iddanhmuc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007475");
        });

        modelBuilder.Entity<Mausacsanpham>(entity =>
        {
            entity.HasKey(e => e.Idmausac).HasName("SYS_C007500");

            entity.ToTable("MAUSACSANPHAM");

            entity.HasIndex(e => e.Tenmau, "SYS_C007501").IsUnique();

            entity.Property(e => e.Idmausac)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDMAUSAC");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");
            entity.Property(e => e.Mota)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("MOTA");
            entity.Property(e => e.Tenmau)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENMAU");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Mausacsanphams)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007502");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Idnhanvien).HasName("SYS_C007520");

            entity.ToTable("NHANVIEN");

            entity.HasIndex(e => e.Sodienthoai, "SYS_C007521").IsUnique();

            entity.Property(e => e.Idnhanvien)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Diachinhanvien)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DIACHINHANVIEN");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Gmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GMAIL");
            entity.Property(e => e.Hotennhanvien)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HOTENNHANVIEN");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("DATE")
                .HasColumnName("NGAYSINH");
            entity.Property(e => e.Ngaytuyendung)
                .HasColumnType("DATE")
                .HasColumnName("NGAYTUYENDUNG");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SODIENTHOAI");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRANGTHAI");
        });

        modelBuilder.Entity<Phieunhap>(entity =>
        {
            entity.HasKey(e => e.Idphieunhap).HasName("SYS_C007605");

            entity.ToTable("PHIEUNHAP");

            entity.Property(e => e.Idphieunhap)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDPHIEUNHAP");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Idnhanvien)
                .HasColumnType("NUMBER")
                .HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Ngaynhap)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("NGAYNHAP");
            entity.Property(e => e.Tongtien)
                .HasColumnType("NUMBER")
                .HasColumnName("TONGTIEN");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Phieunhaps)
                .HasForeignKey(d => d.Idnhanvien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007606");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Idsanpham).HasName("SYS_C007481");

            entity.ToTable("SANPHAM");

            entity.HasIndex(e => e.Tensanpham, "SYS_C007482").IsUnique();

            entity.Property(e => e.Idsanpham)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");
            entity.Property(e => e.Giagoc)
                .HasColumnType("NUMBER")
                .HasColumnName("GIAGOC");
            entity.Property(e => e.Giakhuyenmai)
                .HasColumnType("NUMBER")
                .HasColumnName("GIAKHUYENMAI");
            entity.Property(e => e.Idloaisanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDLOAISANPHAM");
            entity.Property(e => e.Tensanpham)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENSANPHAM");

            entity.HasOne(d => d.IdloaisanphamNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Idloaisanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007483");
        });

        modelBuilder.Entity<Thanhtoan>(entity =>
        {
            entity.HasKey(e => e.Idthanhtoan).HasName("SYS_C007578");

            entity.ToTable("THANHTOAN");

            entity.Property(e => e.Idthanhtoan)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDTHANHTOAN");
            entity.Property(e => e.Iddonhang)
                .HasColumnType("NUMBER")
                .HasColumnName("IDDONHANG");
            entity.Property(e => e.Magiaodich)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MAGIAODICH");
            entity.Property(e => e.Ngaythanhtoan)
                .HasColumnType("DATE")
                .HasColumnName("NGAYTHANHTOAN");
            entity.Property(e => e.Phuongthucthanhtoan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PHUONGTHUCTHANHTOAN");
            entity.Property(e => e.Trangthaithanhtoan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRANGTHAITHANHTOAN");

            entity.HasOne(d => d.IddonhangNavigation).WithMany(p => p.Thanhtoans)
                .HasForeignKey(d => d.Iddonhang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007579");
        });

        modelBuilder.Entity<Tintuc>(entity =>
        {
            entity.HasKey(e => e.Idtintuc).HasName("SYS_C007572");

            entity.ToTable("TINTUC");

            entity.HasIndex(e => e.Tentintuc, "SYS_C007573").IsUnique();

            entity.Property(e => e.Idtintuc)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDTINTUC");
            entity.Property(e => e.Idnhanvien)
                .HasColumnType("NUMBER")
                .HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Ngaytao)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("NGAYTAO");
            entity.Property(e => e.Tentintuc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TENTINTUC");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Tintucs)
                .HasForeignKey(d => d.Idnhanvien)
                .HasConstraintName("SYS_C007574");
        });

        modelBuilder.Entity<Tonkho>(entity =>
        {
            entity.HasKey(e => e.Idtonkho).HasName("SYS_C007544");

            entity.ToTable("TONKHO");

            entity.Property(e => e.Idtonkho)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDTONKHO");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");
            entity.Property(e => e.Soluongcanhbao)
                .HasColumnType("NUMBER")
                .HasColumnName("SOLUONGCANHBAO");
            entity.Property(e => e.Soluongton)
                .HasColumnType("NUMBER")
                .HasColumnName("SOLUONGTON");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Tonkhos)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007545");
        });

        modelBuilder.Entity<Yeuthich>(entity =>
        {
            entity.HasKey(e => e.Idyeuthich).HasName("SYS_C007586");

            entity.ToTable("YEUTHICH");

            entity.Property(e => e.Idyeuthich)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDYEUTHICH");
            entity.Property(e => e.Idkhachhang)
                .HasColumnType("NUMBER")
                .HasColumnName("IDKHACHHANG");
            entity.Property(e => e.Idsanpham)
                .HasColumnType("NUMBER")
                .HasColumnName("IDSANPHAM");

            entity.HasOne(d => d.IdkhachhangNavigation).WithMany(p => p.Yeuthiches)
                .HasForeignKey(d => d.Idkhachhang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007587");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Yeuthiches)
                .HasForeignKey(d => d.Idsanpham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C007588");
        });
        modelBuilder.HasSequence("SEQ_SAN_PHAM_ID");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
