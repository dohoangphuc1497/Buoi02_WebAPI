using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Buoi02_WebAPI.Models
{
    public partial class NhatNgheWebAPIContext : DbContext
    {
        public NhatNgheWebAPIContext()
        {
        }

        public NhatNgheWebAPIContext(DbContextOptions<NhatNgheWebAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietHd> ChiTietHd { get; set; }
        public virtual DbSet<HangHoa> HangHoa { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<Loai> Loai { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<VaiTro> VaiTro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.; Database=NhatNgheWebAPI; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHd>(entity =>
            {
                entity.HasKey(e => e.MaCt)
                    .HasName("PK_OrderDetails");

                entity.ToTable("ChiTietHD");

                entity.Property(e => e.MaCt).HasColumnName("MaCT");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.ChiTietHd)
                    .HasForeignKey(d => d.MaHd)
                    .HasConstraintName("FK_ChiTietHD_HoaDon");

                entity.HasOne(d => d.MaHhNavigation)
                    .WithMany(p => p.ChiTietHd)
                    .HasForeignKey(d => d.MaHh)
                    .HasConstraintName("FK_ChiTietHD_HangHoa");
            });

            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.HasKey(e => e.MaHh)
                    .HasName("PK_Products");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.MaNcc)
                    .IsRequired()
                    .HasColumnName("MaNCC")
                    .HasMaxLength(50);

                entity.Property(e => e.MoTaDonVi).HasMaxLength(50);

                entity.Property(e => e.NgaySx)
                    .HasColumnName("NgaySX")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenHh)
                    .IsRequired()
                    .HasColumnName("TenHH")
                    .HasMaxLength(40);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.HangHoa)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HangHoa_Loai");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.HangHoa)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HangHoa_NhaCungCap");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK_Orders");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.CachThanhToan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CachVanChuyen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaKh)
                    .IsRequired()
                    .HasColumnName("MaKH")
                    .HasMaxLength(20);

                entity.Property(e => e.MaVn)
                    .HasColumnName("MaVN")
                    .HasMaxLength(50);

                entity.Property(e => e.NgayCan).HasColumnType("datetime");

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_KhachHang");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK_Customers");

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(20);

                entity.Property(e => e.DiaChi).HasMaxLength(60);

                entity.Property(e => e.DienThoai).HasMaxLength(24);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            });

            modelBuilder.Entity<Loai>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK_Categories");

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.TenDangNhap);

                entity.Property(e => e.TenDangNhap).HasMaxLength(20);

                entity.Property(e => e.DiaChi).HasMaxLength(60);

                entity.Property(e => e.DienThoai).HasMaxLength(24);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(250);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.RandomKey)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.VaiTro)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.VaiTroNavigation)
                    .WithMany(p => p.NguoiDung)
                    .HasForeignKey(d => d.VaiTro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NguoiDung_VaiTro");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK_Suppliers");

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(50);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NguoiLienLac).HasMaxLength(50);

                entity.Property(e => e.TenCongTy)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VaiTro>(entity =>
            {
                entity.HasKey(e => e.MaVt)
                    .HasName("PK_PhongBan");

                entity.Property(e => e.MaVt)
                    .HasColumnName("MaVT")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TenVaiTro)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
