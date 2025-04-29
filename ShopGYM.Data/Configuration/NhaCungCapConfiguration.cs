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
    public class NhaCungCapConfiguration : IEntityTypeConfiguration<NhaCungCap>
    {
        public void Configure(EntityTypeBuilder<NhaCungCap> entity)
        {
            entity.ToTable("NhaCungCap");
            entity.HasKey(ncc => ncc.MaNhaCungCap);
            entity.Property(ncc => ncc.MaNhaCungCap).ValueGeneratedOnAdd();
            entity.Property(ncc => ncc.TenNhaCungCap).IsRequired().HasMaxLength(100);
            entity.Property(ncc => ncc.DiaChi);
            entity.Property(ncc => ncc.SoDienThoai).HasMaxLength(15);
            entity.Property(ncc => ncc.Email).HasMaxLength(100);
        }
    }
}
