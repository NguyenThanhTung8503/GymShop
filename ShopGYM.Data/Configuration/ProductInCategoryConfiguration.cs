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
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> entity)
        {
            entity.HasKey(t => new { t.MaDanhMuc, t.MaSanPham });

            entity.ToTable("ProductInCategory");

            entity.HasOne(t => t.SanPham).WithMany(pc => pc.ProductInCategories)
                .HasForeignKey(pc => pc.MaSanPham);

            entity.HasOne(t => t.DanhMuc).WithMany(pc => pc.ProductInCategories)
              .HasForeignKey(pc => pc.MaDanhMuc);

        }
    }
}
