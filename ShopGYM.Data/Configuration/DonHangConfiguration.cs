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
    public class DonHangConfiguration : IEntityTypeConfiguration<DonHang>
    {
        public void Configure(EntityTypeBuilder<DonHang> entity)
        {
            entity.ToTable("DonHang");
            entity.HasKey(dh => dh.MaDonHang);
            entity.Property(dh => dh.MaDonHang).ValueGeneratedOnAdd();
            entity.Property(dh => dh.MaNguoiDung).IsRequired();
            entity.Property(dh => dh.NgayDatHang).IsRequired();
            entity.Property(dh => dh.TongTien).IsRequired().HasColumnType("DECIMAL(18,2)");
            entity.Property(dh => dh.TrangThai).IsRequired().HasMaxLength(50).HasConversion<string>();
            entity.Property(dh => dh.PhuongThucThanhToan).HasMaxLength(50).HasConversion<string>();
            entity.Property(dh => dh.DiaChiGiaoHang);

            entity.HasOne(dh => dh.AppUser)
                  .WithMany(nd => nd.DonHangs)
                  .HasForeignKey(dh => dh.MaNguoiDung);
        }
    }
}
