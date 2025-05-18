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
                
                entity.HasKey(x => new { x.MaDonHang, x.MaSanPham });
                
                entity.HasOne(x => x.DonHang).WithMany(x => x.ChiTietDonHangs).HasForeignKey(x => x.MaDonHang);
                entity.HasOne(x => x.SanPham).WithMany(x => x.ChiTietDonHangs).HasForeignKey(x => x.MaSanPham).OnDelete(DeleteBehavior.NoAction);

        }
    }
    
}
