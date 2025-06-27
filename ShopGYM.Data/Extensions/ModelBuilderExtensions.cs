using Braintree;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using ShopGYM.Data.Entities;
using ShopGYM.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // any guid
            var roleId = new Guid("8E15262E-8583-4C49-86BE-CEF2BF4345D1");
            var adminId = new Guid("90B411BE-A570-4839-8F59-492EDCC9520D");
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            // Seed NguoiDung
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "Nguyenthanhutung0168I@gmail.com",
                NormalizedEmail = "Nguyenthanhutung0168I@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEM46oTWgZoplJc03cruZtbZl0U+oFphoPy/WIUKRg7ddeIhiiLck/8cFrJw6UnM+MQ==",//do lỗi seeding nên để pass băm sẵn pass là Tung1234,
                ConcurrencyStamp = "1f2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d", // Giá trị cố định
                SecurityStamp = string.Empty,
                FirstName = "Nguyen",
                LastName = "Tung",
                Dob = new DateTime(2003, 05, 08)
            });

            // Seed Role
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                MoTa = "Quan Tri"
            });
            // Seed DanhMuc
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc { MaDanhMuc = 1, TenDanhMuc = "Quan", MoTa = "Quần các loại" },
                new DanhMuc { MaDanhMuc = 2, TenDanhMuc = "Ao", MoTa = "Áo thời trang" },
                new DanhMuc { MaDanhMuc = 3, TenDanhMuc = "Giay", MoTa = "Giày thể thao và thời trang" },
                new DanhMuc { MaDanhMuc = 4, TenDanhMuc = "PhuKien", MoTa = "Phụ kiện thời trang" }
            );
            
        }
    }
}
