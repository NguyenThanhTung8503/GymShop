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
    public class ChiTietDonHangConfiguration : IEntityTypeConfiguration<ChiTietDonHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietDonHang> entity)
        {
            entity.ToTable("ChiTietDonHang");
            entity.HasKey(ct => ct.MaChiTietDonHang);
            entity.Property(ct => ct.MaChiTietDonHang).ValueGeneratedOnAdd();
            entity.Property(ct => ct.MaDonHang).IsRequired();
            entity.Property(ct => ct.MaSanPham).IsRequired();
            entity.Property(ct => ct.SoLuong).IsRequired();
            entity.Property(ct => ct.GiaBan).IsRequired().HasColumnType("DECIMAL(18,2)");

            entity.HasOne(ct => ct.DonHang)
                  .WithMany(dh => dh.ChiTietDonHangs)
                  .HasForeignKey(ct => ct.MaDonHang);

            entity.HasOne(ct => ct.SanPham)
                  .WithMany(sp => sp.ChiTietDonHangs)
                  .HasForeignKey(ct => ct.MaSanPham);
        }
    }
}
