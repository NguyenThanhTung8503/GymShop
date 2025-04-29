using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopGYM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Configuration
{
    public class DanhMucConfiguration : IEntityTypeConfiguration<DanhMuc>
    {
        public void Configure(EntityTypeBuilder<DanhMuc> entity)
        {
            entity.ToTable("DanhMuc");
            entity.HasKey(dm => dm.MaDanhMuc);
            entity.Property(dm => dm.MaDanhMuc).ValueGeneratedOnAdd();
            entity.Property(dm => dm.TenDanhMuc).IsRequired().HasMaxLength(100);
            entity.Property(dm => dm.MoTa).HasMaxLength(255);
        }
    }
}
