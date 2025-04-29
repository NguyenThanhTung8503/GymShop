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
    public class DanhGiaConfiguration : IEntityTypeConfiguration<DanhGia>
    {
        public void Configure(EntityTypeBuilder<DanhGia> entity)
        {
            entity.ToTable("DanhGia");
            entity.HasKey(dg => dg.MaDanhGia);
            entity.Property(dg => dg.MaDanhGia).ValueGeneratedOnAdd();
            entity.Property(dg => dg.MaSanPham).IsRequired();
            entity.Property(dg => dg.MaNguoiDung).IsRequired();
            entity.Property(dg => dg.NoiDung).IsRequired();
            entity.Property(dg => dg.NgayDanhGia).IsRequired();

            entity.HasOne(dg => dg.SanPham)
                  .WithMany(sp => sp.DanhGias)
                  .HasForeignKey(dg => dg.MaSanPham);

            entity.HasOne(dg => dg.AppUser)
                  .WithMany(nd => nd.DanhGias)
                  .HasForeignKey(dg => dg.MaNguoiDung);
        }
    }
}
