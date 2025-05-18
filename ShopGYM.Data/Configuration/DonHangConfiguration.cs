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
            entity.Property(dh => dh.NgayDatHang);
            entity.Property(dh => dh.DiaChiGiaoHang);
            entity.Property(dh => dh.SDT);

            entity.HasOne(dh => dh.AppUser)
                  .WithMany(nd => nd.DonHangs)
                  .HasForeignKey(dh => dh.MaNguoiDung);
        }
    }
}
