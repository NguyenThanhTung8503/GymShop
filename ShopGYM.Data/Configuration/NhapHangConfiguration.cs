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
    public class NhapHangConfiguration : IEntityTypeConfiguration<NhapHang>
    {
        public void Configure(EntityTypeBuilder<NhapHang> entity)
        {
            entity.ToTable("NhapHang");
            entity.HasKey(nh => nh.MaNhapHang);
            entity.Property(nh => nh.MaNhapHang).ValueGeneratedOnAdd();
            entity.Property(nh => nh.MaNhaCungCap).IsRequired();
            entity.Property(nh => nh.NgayNhap).IsRequired();
            entity.Property(nh => nh.TongTien).IsRequired().HasColumnType("DECIMAL(18,2)");
            entity.Property(nh => nh.GhiChu);

            entity.HasOne(nh => nh.NhaCungCap)
                  .WithMany(ncc => ncc.NhapHangs)
                  .HasForeignKey(nh => nh.MaNhaCungCap);
        }
    }
}
