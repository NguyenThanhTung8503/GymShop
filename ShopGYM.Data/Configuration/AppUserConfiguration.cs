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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity.ToTable("AppUsers");

            entity.Property(nd => nd.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(nd => nd.LastName).IsRequired().HasMaxLength(200);
            entity.Property(nd => nd.Dob).IsRequired();
        }
    }
}
