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
    public class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> entity)
        {
            entity.ToTable("GioHang");
            entity.HasKey(gh => gh.MaGioHang);
            entity.Property(gh => gh.MaGioHang).ValueGeneratedOnAdd();
            entity.Property(gh => gh.MaNguoiDung).IsRequired();
            entity.Property(gh => gh.MaSanPham).IsRequired();
            entity.Property(gh => gh.SoLuong).IsRequired();

            entity.HasOne(gh => gh.AppUser)
                  .WithMany(nd => nd.GioHangs)
                  .HasForeignKey(gh => gh.MaNguoiDung);

            entity.HasOne(gh => gh.SanPham)
                  .WithMany(sp => sp.GioHangs)
                  .HasForeignKey(gh => gh.MaSanPham);
        }
    }
}
