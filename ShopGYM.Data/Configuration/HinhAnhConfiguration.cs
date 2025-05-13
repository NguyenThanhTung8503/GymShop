using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopGYM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Configuration
{
    public class HinhAnhConfiguration : IEntityTypeConfiguration<HinhAnh>
    {
        public void Configure(EntityTypeBuilder<HinhAnh> entity)
        {
            entity.ToTable("HinhAnh");
            entity.HasKey(ha => ha.MaHinhAnh);
            entity.Property(ha => ha.MaHinhAnh).ValueGeneratedOnAdd();
            entity.Property(ha => ha.DuongDan).IsRequired(true).HasMaxLength(255);
            entity.Property(ha => ha.Mota).HasDefaultValue(0);

            entity.HasOne(ha => ha.SanPham)
                  .WithMany(sp => sp.HinhAnhs)
                  .HasForeignKey(ha => ha.MaSanPham)
                  .OnDelete(DeleteBehavior.NoAction); 

            entity.HasOne(ha => ha.DanhGia)
                  .WithMany(dg => dg.HinhAnhs)
                  .HasForeignKey(ha => ha.MaDanhGia)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
