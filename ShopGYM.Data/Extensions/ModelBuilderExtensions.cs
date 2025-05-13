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
            // Seed ProductInCategory
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory { MaSanPham = 1, MaDanhMuc = 1},
                new ProductInCategory { MaSanPham = 2, MaDanhMuc = 1 },
                new ProductInCategory { MaSanPham = 3, MaDanhMuc = 2 },
                new ProductInCategory { MaSanPham = 4, MaDanhMuc = 2 },
                new ProductInCategory { MaSanPham = 5, MaDanhMuc = 3 }

            );

            // Seed SanPham
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham { MaSanPham = 1, NgayTao = new DateTime(2025, 5, 1), TenSanPham = "Quần Jeans Nam", Gia = 350000, MoTa = "Quần jeans nam phong cách", KichThuoc = "M", MauSac = "Xanh đậm", SoLuongTon = 50 },
                new SanPham { MaSanPham = 2, NgayTao = new DateTime(2025, 5, 1), TenSanPham = "Quần Kaki Nữ", Gia = 280000, MoTa = "Quần kaki nữ thời trang", KichThuoc = "S", MauSac = "Beige", SoLuongTon = 40 },
                new SanPham { MaSanPham = 3, NgayTao = new DateTime(2025, 5, 1), TenSanPham = "Áo Thun Nam", Gia = 150000, MoTa = "Áo thun nam cotton", KichThuoc = "L", MauSac = "Trắng", SoLuongTon = 100 },
                new SanPham { MaSanPham = 4, NgayTao = new DateTime(2025, 5, 1), TenSanPham = "Áo Sơ Mi Nữ", Gia = 250000, MoTa = "Áo sơ mi nữ công sở", KichThuoc = "M", MauSac = "Xanh nhạt", SoLuongTon = 30 },
                new SanPham { MaSanPham = 5, NgayTao = new DateTime(2025, 5, 1), TenSanPham = "Giày Sneaker Nam", Gia = 650000, MoTa = "Giày sneaker nam thời trang", KichThuoc = "L", MauSac = "Đen", SoLuongTon = 25 }
           
            );

            // Seed NhaCungCap
            modelBuilder.Entity<NhaCungCap>().HasData(
                new NhaCungCap { MaNhaCungCap = 1, TenNhaCungCap = "Công ty TNHH May Mặc ABC", DiaChi = "123 Factory St, Hanoi", SoDienThoai = "0901234560", Email = "abc@company.com" },
                new NhaCungCap { MaNhaCungCap = 2, TenNhaCungCap = "Công ty Giày XYZ", DiaChi = "456 Factory St, HCMC", SoDienThoai = "0901234561", Email = "xyz@company.com" },
                new NhaCungCap { MaNhaCungCap = 3, TenNhaCungCap = "Công ty Phụ Kiện 123", DiaChi = "789 Factory St, Danang", SoDienThoai = "0901234562", Email = "123@company.com" },
                new NhaCungCap { MaNhaCungCap = 4, TenNhaCungCap = "Công ty Thời Trang DEF", DiaChi = "321 Factory St, Hanoi", SoDienThoai = "0901234563", Email = "def@company.com" }
            );

            // Seed NhapHang
            modelBuilder.Entity<NhapHang>().HasData(
                new NhapHang { MaNhapHang = 1, MaNhaCungCap = 1, NgayNhap = new DateTime(2025, 4, 5, 8, 0, 0), TongTien = 5000000, GhiChu = "Nhập lô quần jeans" },
                new NhapHang { MaNhapHang = 2, MaNhaCungCap = 2, NgayNhap = new DateTime(2025, 4, 10, 9, 0, 0), TongTien = 8000000, GhiChu = "Nhập lô giày sneaker" },
                new NhapHang { MaNhapHang = 3, MaNhaCungCap = 3, NgayNhap = new DateTime(2025, 4, 15, 10, 0, 0), TongTien = 2000000, GhiChu = "Nhập lô phụ kiện" },
                new NhapHang { MaNhapHang = 4, MaNhaCungCap = 4, NgayNhap = new DateTime(2025, 4, 20, 11, 0, 0), TongTien = 6000000, GhiChu = "Nhập lô áo thun" }
            );

            // Seed ChiTietNhapHang
            modelBuilder.Entity<ChiTietNhapHang>().HasData(
                new ChiTietNhapHang { MaChiTietNhapHang = 1, MaNhapHang = 1, MaSanPham = 1, SoLuong = 50, GiaNhap = 200000 },
                new ChiTietNhapHang { MaChiTietNhapHang = 2, MaNhapHang = 2, MaSanPham = 5, SoLuong = 30, GiaNhap = 400000 },
                new ChiTietNhapHang { MaChiTietNhapHang = 3, MaNhapHang = 3, MaSanPham = 4, SoLuong = 100, GiaNhap = 80000 },
                new ChiTietNhapHang { MaChiTietNhapHang = 4, MaNhapHang = 4, MaSanPham = 3, SoLuong = 150, GiaNhap = 100000 }
            );

            // Seed HinhAnh
            modelBuilder.Entity<HinhAnh>().HasData(
                // Ảnh sản phẩm cho 13 sản phẩm
                new HinhAnh { MaHinhAnh = 1, DuongDan = "/images/jeans.jpg", MaSanPham = 1, Mota = "Hình quần jeans nam", NgayTao = new DateTime(2025, 3, 26, 8, 0, 0), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 2, DuongDan = "/images/kaki.jpg", MaSanPham = 2, Mota = "Hình quần kaki nữ", NgayTao = new DateTime(2025, 3, 26, 8, 0, 0), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 3, DuongDan = "/images/tshirt.jpg", MaSanPham = 3, Mota = "Hình áo thun nam", NgayTao = new DateTime(2025, 3, 26, 8, 0, 0), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 4, DuongDan = "/images/shirt.jpg", MaSanPham = 4, Mota = "Hình áo sơ mi nữ", NgayTao = new DateTime(2025, 3, 26, 8, 0, 0), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 5, DuongDan = "/images/sneaker.jpg", MaSanPham = 5, Mota = "Hình giày sneaker nam", NgayTao = new DateTime(2025, 3, 26, 8, 0, 0), MaDanhGia = null, IsDefault = true }
                
             );
        }
    }
}
