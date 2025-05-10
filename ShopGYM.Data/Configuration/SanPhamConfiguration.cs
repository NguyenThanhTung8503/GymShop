using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopGYM.Data.Entities;

namespace ShopGYM.Data.Configuration
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> entity)
        {
            entity.ToTable("SanPham");
            entity.HasKey(sp => sp.MaSanPham);
            entity.Property(sp => sp.MaSanPham).ValueGeneratedOnAdd();
            entity.Property(sp => sp.TenSanPham).IsRequired().HasMaxLength(100);
            entity.Property(sp => sp.Gia).IsRequired().HasColumnType("DECIMAL(18,2)");
            entity.Property(sp => sp.MoTa);
            entity.Property(sp => sp.KichThuoc).HasMaxLength(50);
            entity.Property(sp => sp.MauSac).HasMaxLength(50);
            entity.Property(sp => sp.SoLuongTon).IsRequired();

            
        }
    }
}
