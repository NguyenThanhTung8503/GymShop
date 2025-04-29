using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopGYM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Configuration
{
    public class ChiTietNhapHangConfiguration : IEntityTypeConfiguration<ChiTietNhapHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietNhapHang> entity)
        {
            entity.ToTable("ChiTietNhapHang");
            entity.HasKey(ct => ct.MaChiTietNhapHang);
            entity.Property(ct => ct.MaChiTietNhapHang).ValueGeneratedOnAdd();
            entity.Property(ct => ct.MaNhapHang).IsRequired();
            entity.Property(ct => ct.MaSanPham).IsRequired();
            entity.Property(ct => ct.SoLuong).IsRequired();
            entity.Property(ct => ct.GiaNhap).IsRequired().HasColumnType("DECIMAL(18,2)");

            entity.HasOne(ct => ct.NhapHang)
                  .WithMany(nh => nh.ChiTietNhapHangs)
                  .HasForeignKey(ct => ct.MaNhapHang);

            entity.HasOne(ct => ct.SanPham)
                  .WithMany(sp => sp.ChiTietNhapHangs)
                  .HasForeignKey(ct => ct.MaSanPham);
        }
    }
}
