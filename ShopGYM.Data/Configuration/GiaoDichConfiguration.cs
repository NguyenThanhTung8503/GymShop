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
    public class GiaoDichConfiguration : IEntityTypeConfiguration<GiaoDich>
    {
        public void Configure(EntityTypeBuilder<GiaoDich> entity)
        {
            entity.ToTable("GiaoDich");
            entity.HasKey(gd => gd.MaGiaoDich);
            entity.Property(gd => gd.MaGiaoDich).ValueGeneratedOnAdd();
            entity.Property(gd => gd.MaDonHang).IsRequired();
            entity.Property(gd => gd.MaGiaoDichCuaCong).HasMaxLength(100);
            entity.Property(gd => gd.SoTien).IsRequired().HasColumnType("DECIMAL(18,2)");
            entity.Property(gd => gd.TrangThai).IsRequired().HasMaxLength(50).HasConversion<string>();
            entity.Property(gd => gd.NgayGiaoDich).IsRequired();
            entity.Property(gd => gd.CongThanhToan).HasMaxLength(50).HasConversion<string>();

            entity.HasOne(gd => gd.DonHang)
                  .WithMany(dh => dh.GiaoDichs)
                  .HasForeignKey(gd => gd.MaDonHang);
        }
    }
}
