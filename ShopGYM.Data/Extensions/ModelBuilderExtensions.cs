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

            // Seed AppRoles
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = new Guid("b4a61976-a013-4c49-af27-3eff86cb4a25"),
                    MoTa = "Nhân viên",
                    Name = "NhanVien",
                    NormalizedName = "NhanVien",
                    ConcurrencyStamp = null
                },
                new AppRole
                {
                    Id = new Guid("5bc70ed5-b04d-4b8f-9fc0-588f0e6c1962"),
                    MoTa = "Khách hàng",
                    Name = "KhachHang",
                    NormalizedName = "KhachHang",
                    ConcurrencyStamp = null
                },
                new AppRole
                {
                    Id = new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1"),
                    MoTa = "Quan Tri",
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = null
                }
            );

            // Seed AppUserRoles
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"),
                    RoleId = new Guid("5bc70ed5-b04d-4b8f-9fc0-588f0e6c1962")
                },
                new IdentityUserRole<Guid>
                {
                    UserId = new Guid("bb100ea3-aa44-42da-f858-08ddb2449214"),
                    RoleId = new Guid("b4a61976-a013-4c49-af27-3eff86cb4a25")
                },
                new IdentityUserRole<Guid>
                {
                    UserId = new Guid("90b411be-a570-4839-8f59-492edcc9520d"),
                    RoleId = new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1")
                }
            );

            // Seed AppUsers
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"),
                    FirstName = "Tung",
                    LastName = "test1",
                    Dob = new DateTime(2025, 05, 08),
                    UserName = "Tung1",
                    NormalizedUserName = "TUNG1",
                    Email = "iuytutgyu@gmail.com",
                    NormalizedEmail = "IUYTUTGYU@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAECstnv1pwi32bsYGqUrk8Ty+qp9tERfUmi7TkUPoBbcDAMlqaNz8m+PMb6Kd6cs+DA==",
                    SecurityStamp = "PQG4BV4ZOAADMF42KJCZYXOWJY56WETU",
                    ConcurrencyStamp = "f518d7a4-a59e-40f7-8076-a42d549cea2b",
                    PhoneNumber = "877845832",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new AppUser
                {
                    Id = new Guid("bb100ea3-aa44-42da-f858-08ddb2449214"),
                    FirstName = "Nguyen",
                    LastName = "Nam",
                    Dob = new DateTime(2025, 06, 21),
                    UserName = "Nam",
                    NormalizedUserName = "NAM",
                    Email = "iuytutgyusaduw@gmail.com",
                    NormalizedEmail = "IUYTUTGYUSADUW@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEKsZaSL4UT2Ktcmm8MP58qEHdMOkoK/fhkWY3yXAm93y3reJc1xjGEOP+W+un8P5TA==",
                    SecurityStamp = "I4A55LKLPNEJTJZ4VHFC5AHXYYQU55WM",
                    ConcurrencyStamp = "6bc86b57-7eed-4cfe-8fde-087c544822b6",
                    PhoneNumber = "03858445213",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new AppUser
                {
                    Id = new Guid("90b411be-a570-4839-8f59-492edcc9520d"),
                    FirstName = "Nguyen",
                    LastName = "Thanh Tung",
                    Dob = new DateTime(2003, 05, 08),
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "Nguyenthanhutung0168I@gmail.com",
                    NormalizedEmail = "NGUYENTHANHUTUNG0168I@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEM46oTWgZoplJc03cruZtbZl0U+oFphoPy/WIUKRg7ddeIhiiLck/8cFrJw6UnM+MQ==",
                    SecurityStamp = "",
                    ConcurrencyStamp = "578401e0-da12-431f-89c0-bc8e44c0d119",
                    PhoneNumber = "0385844597",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
            );

            // Seed ChiTietDonHang
            modelBuilder.Entity<ChiTietDonHang>().HasData(
                new ChiTietDonHang { MaDonHang = 48, MaSanPham = 2, SoLuong = 2, Gia = 350000.00M },
                new ChiTietDonHang { MaDonHang = 48, MaSanPham = 3, SoLuong = 1, Gia = 150000.00M },
                new ChiTietDonHang { MaDonHang = 49, MaSanPham = 1, SoLuong = 1, Gia = 150000.00M },
                new ChiTietDonHang { MaDonHang = 50, MaSanPham = 14, SoLuong = 1, Gia = 200000.00M },
                new ChiTietDonHang { MaDonHang = 51, MaSanPham = 2, SoLuong = 1, Gia = 175000.00M },
                new ChiTietDonHang { MaDonHang = 52, MaSanPham = 2, SoLuong = 1, Gia = 175000.00M },
                new ChiTietDonHang { MaDonHang = 52, MaSanPham = 8, SoLuong = 1, Gia = 1200000.00M }
            );

            // Seed DanhGia
            modelBuilder.Entity<DanhGia>().HasData(
                new DanhGia
                {
                    MaDanhGia = 2,
                    MaSanPham = 2,
                    MaNguoiDung = new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"),
                    NoiDung = "ngon bổ đấy",
                    NgayDanhGia = new DateTime(2025, 05, 28, 21, 49, 29, 771, DateTimeKind.Utc).AddTicks(5274)
                },
                new DanhGia
                {
                    MaDanhGia = 4,
                    MaSanPham = 2,
                    MaNguoiDung = new Guid("90b411be-a570-4839-8f59-492edcc9520d"),
                    NoiDung = "hehehehe",
                    NgayDanhGia = new DateTime(2025, 05, 29, 15, 01, 46, 590, DateTimeKind.Utc).AddTicks(1833)
                },
                new DanhGia
                {
                    MaDanhGia = 5,
                    MaSanPham = 2,
                    MaNguoiDung = new Guid("90b411be-a570-4839-8f59-492edcc9520d"),
                    NoiDung = "hihihih",
                    NgayDanhGia = new DateTime(2025, 05, 29, 15, 02, 00, 409, DateTimeKind.Utc).AddTicks(6741)
                }
            );

            // Seed DanhMuc
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc { MaDanhMuc = 1, TenDanhMuc = "Quan", MoTa = "Quần các loại" },
                new DanhMuc { MaDanhMuc = 2, TenDanhMuc = "Ao", MoTa = "Áo thời trang" },
                new DanhMuc { MaDanhMuc = 3, TenDanhMuc = "Giay", MoTa = "Giày thể thao và thời trang" },
                new DanhMuc { MaDanhMuc = 4, TenDanhMuc = "PhuKien", MoTa = "Phụ kiện thời trang" }
            );

            // Seed DonHang
            modelBuilder.Entity<DonHang>().HasData(
                new DonHang
                {
                    MaDonHang = 47,
                    MaNguoiDung = new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"),
                    NgayDatHang = new DateTime(2025, 05, 28, 20, 12, 46, 579, DateTimeKind.Utc).AddTicks(7613),
                    DiaChiGiaoHang = "ểw",
                    SDT = "0385844589",
                    TenNguoiNhan = "tung",
                    PhuongThucThanhToan = "Momo",
                    TrangThai = "Đang giao"
                },
                new DonHang
                {
                    MaDonHang = 48,
                    MaNguoiDung = new Guid("90b411be-a570-4839-8f59-492edcc9520d"),
                    NgayDatHang = new DateTime(2025, 06, 11, 10, 01, 53, 978, DateTimeKind.Utc).AddTicks(1287),
                    DiaChiGiaoHang = "ninh bình",
                    SDT = "0385844556",
                    TenNguoiNhan = "tung",
                    PhuongThucThanhToan = "Momo",
                    TrangThai = "Đã giao"
                },
                new DonHang
                {
                    MaDonHang = 49,
                    MaNguoiDung = new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"),
                    NgayDatHang = new DateTime(2025, 06, 12, 15, 45, 54, 017, DateTimeKind.Utc).AddTicks(9282),
                    DiaChiGiaoHang = "ninh bình",
                    SDT = "0385844556",
                    TenNguoiNhan = "tung",
                    PhuongThucThanhToan = "COD",
                    TrangThai = "Đã giao"
                },
                new DonHang
                {
                    MaDonHang = 50,
                    MaNguoiDung = new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"),
                    NgayDatHang = new DateTime(2025, 06, 12, 16, 09, 27, 631, DateTimeKind.Utc).AddTicks(5490),
                    DiaChiGiaoHang = "ninh bình",
                    SDT = "0385844556",
                    TenNguoiNhan = "tung",
                    PhuongThucThanhToan = "Momo",
                    TrangThai = "Đang giao"
                },
                new DonHang
                {
                    MaDonHang = 51,
                    MaNguoiDung = new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"),
                    NgayDatHang = new DateTime(2025, 06, 22, 15, 30, 13, 795, DateTimeKind.Utc).AddTicks(4134),
                    DiaChiGiaoHang = "ểw",
                    SDT = "0385844389",
                    TenNguoiNhan = "tung",
                    PhuongThucThanhToan = "COD",
                    TrangThai = "Đang xử lý"
                },
                new DonHang
                {
                    MaDonHang = 52,
                    MaNguoiDung = new Guid("47cafa38-48eb-4eff-0ac5-08dd955ceca4"),
                    NgayDatHang = new DateTime(2025, 07, 03, 16, 46, 50, 769, DateTimeKind.Utc).AddTicks(2810),
                    DiaChiGiaoHang = "ninh bình",
                    SDT = "0385844592",
                    TenNguoiNhan = "tung",
                    PhuongThucThanhToan = "COD",
                    TrangThai = "Đang xử lý"
                }
            );

            // Seed HinhAnh
            modelBuilder.Entity<HinhAnh>().HasData(
                new HinhAnh { MaHinhAnh = 1, DuongDan = "/user-content/9d87f6cd-d4cb-4fe4-b3ad-3a835ec5963b.png", MaSanPham = 1, Mota = "Hình quần jeans nam đẹp", NgayTao = new DateTime(2025, 05, 14, 12, 53, 34, 082, DateTimeKind.Utc).AddTicks(1737), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 2, DuongDan = "/user-content/7b3698fa-690b-4b2d-b403-dbad0bd39ba1.png", MaSanPham = 2, Mota = "Hình quần kaki nữ", NgayTao = new DateTime(2025, 03, 26, 08, 00, 00, 000, DateTimeKind.Utc), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 3, DuongDan = "/user-content/5a960552-f331-450b-85bf-3922c6167f3e.png", MaSanPham = 3, Mota = "Hình áo thun nam", NgayTao = new DateTime(2025, 03, 26, 08, 00, 00, 000, DateTimeKind.Utc), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 4, DuongDan = "/user-content/44ca264f-7b2c-47a5-aca9-eafdc79684f8.png", MaSanPham = 4, Mota = "Hình áo sơ mi nữ", NgayTao = new DateTime(2025, 03, 26, 08, 00, 00, 000, DateTimeKind.Utc), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 5, DuongDan = "/user-content/94f71cd2-508a-4ef2-b000-8355bbd7a45e.png", MaSanPham = 5, Mota = "Hình giày sneaker nam", NgayTao = new DateTime(2025, 03, 26, 08, 00, 00, 000, DateTimeKind.Utc), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 6, DuongDan = "/user-content/bd8574b2-3ddb-4f5a-a90f-5a1033b8b965.webp", MaSanPham = 6, Mota = "Thumbnail Images", NgayTao = new DateTime(2025, 05, 11, 08, 15, 13, 727, DateTimeKind.Utc).AddTicks(6523), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 7, DuongDan = "/user-content/d3b2f6c7-ff0f-4e88-9cf4-ecd5fd2b0c51.png", MaSanPham = 7, Mota = "Thumbnail Images", NgayTao = new DateTime(2025, 05, 12, 18, 10, 30, 817, DateTimeKind.Utc).AddTicks(0913), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 12, DuongDan = "/user-content/f3012e83-c8ed-4824-8cd4-f9a339daf8f2.webp", MaSanPham = 10, Mota = "Thumbnail Images", NgayTao = new DateTime(2025, 05, 13, 14, 51, 32, 015, DateTimeKind.Utc).AddTicks(8324), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 18, DuongDan = "/user-content/35cc0df5-31ec-4738-b24d-7a2daf7627cb.png", MaSanPham = 13, Mota = "Thumbnail Images", NgayTao = new DateTime(2025, 05, 23, 14, 25, 41, 921, DateTimeKind.Utc).AddTicks(0388), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 19, DuongDan = "/user-content/36ceb809-f557-4bdd-bb39-1ae13e9f1e51.png", MaSanPham = 14, Mota = "Thumbnail Images", NgayTao = new DateTime(2025, 05, 25, 13, 53, 33, 552, DateTimeKind.Utc).AddTicks(8252), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 20, DuongDan = "/user-content/e87db1f5-d929-4415-9428-a1a08dddec10.png", MaSanPham = 1, Mota = "rẻ đẹp", NgayTao = new DateTime(2025, 05, 25, 14, 49, 39, 140, DateTimeKind.Utc).AddTicks(5037), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 21, DuongDan = "/user-content/9e9ee8ab-390c-4ef0-b019-c2eac1ac955a.png", MaSanPham = 1, Mota = "rẻ đẹp", NgayTao = new DateTime(2025, 05, 25, 14, 49, 49, 149, DateTimeKind.Utc).AddTicks(5966), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 22, DuongDan = "/user-content/fb475d98-73f8-4f1b-8583-e6042b8d2622.png", MaSanPham = 1, Mota = "test", NgayTao = new DateTime(2025, 05, 25, 14, 49, 59, 834, DateTimeKind.Utc).AddTicks(0412), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 23, DuongDan = "/user-content/12536c9c-8fdd-4bfb-bf1e-dc31ea195022.png", MaSanPham = 1, Mota = "test", NgayTao = new DateTime(2025, 05, 25, 14, 50, 10, 177, DateTimeKind.Utc).AddTicks(0366), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 24, DuongDan = "/user-content/05eef3de-d0fb-493f-8019-ad5b6bc3bb5e.png", MaSanPham = 2, Mota = "test", NgayTao = new DateTime(2025, 05, 25, 14, 52, 43, 848, DateTimeKind.Utc).AddTicks(1474), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 25, DuongDan = "/user-content/5aeae558-cd6a-4665-a87a-69f84c73b225.png", MaSanPham = 2, Mota = "rẻ đẹp", NgayTao = new DateTime(2025, 05, 25, 14, 52, 55, 629, DateTimeKind.Utc).AddTicks(7785), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 26, DuongDan = "/user-content/cb8cfdd2-f5c9-41fd-b497-c2ac18bc747d.png", MaSanPham = 2, Mota = "test", NgayTao = new DateTime(2025, 05, 25, 14, 53, 05, 139, DateTimeKind.Utc).AddTicks(8127), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 27, DuongDan = "/user-content/7df6e485-fddc-48fc-b383-3776cb04e487.jpg", MaSanPham = 2, Mota = "rẻ đẹp", NgayTao = new DateTime(2025, 05, 25, 14, 53, 13, 685, DateTimeKind.Utc).AddTicks(5409), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 28, DuongDan = "/user-content/1f524bf7-d054-476d-893e-de25db4cb9a1.png", MaSanPham = 3, Mota = "rẻ đẹp", NgayTao = new DateTime(2025, 05, 25, 14, 55, 03, 739, DateTimeKind.Utc).AddTicks(9717), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 29, DuongDan = "/user-content/70361097-bc35-4b0c-b125-ac11c8db49d2.png", MaSanPham = 3, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 14, 55, 22, 498, DateTimeKind.Utc).AddTicks(6399), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 30, DuongDan = "/user-content/bcfd0e3b-772c-4788-89e7-9b0d1d1fb882.png", MaSanPham = 3, Mota = "test", NgayTao = new DateTime(2025, 05, 25, 14, 55, 41, 630, DateTimeKind.Utc).AddTicks(2513), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 31, DuongDan = "/user-content/20fd60d1-282d-4560-95de-48c9cdcde892.png", MaSanPham = 4, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 14, 57, 15, 376, DateTimeKind.Utc).AddTicks(1171), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 32, DuongDan = "/user-content/0480112b-2729-43aa-b6cd-262e00bfdf12.png", MaSanPham = 4, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 14, 57, 32, 742, DateTimeKind.Utc).AddTicks(1256), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 33, DuongDan = "/user-content/a1dd908b-517c-4e23-b802-863e6960dc14.jpg", MaSanPham = 4, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 14, 57, 43, 193, DateTimeKind.Utc).AddTicks(3090), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 34, DuongDan = "/user-content/fdd9b59d-3a23-44e9-9e1c-15060e5ca5f4.jpg", MaSanPham = 4, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 14, 57, 51, 181, DateTimeKind.Utc).AddTicks(7814), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 35, DuongDan = "/user-content/7114c9fb-0473-403f-a164-ff27fe9fd86b.png", MaSanPham = 5, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 14, 59, 49, 263, DateTimeKind.Utc).AddTicks(1807), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 36, DuongDan = "/user-content/8802f344-f99d-4a51-92e2-fd939b2930e4.png", MaSanPham = 5, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 15, 00, 14, 239, DateTimeKind.Utc).AddTicks(4353), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 37, DuongDan = "/user-content/2de91d87-c82e-4db1-81e7-a7576f137422.png", MaSanPham = 5, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 15, 00, 30, 219, DateTimeKind.Utc).AddTicks(4082), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 38, DuongDan = "/user-content/75bf5150-2758-4bda-baf7-cf2897135616.png", MaSanPham = 5, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 15, 00, 40, 305, DateTimeKind.Utc).AddTicks(3305), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 39, DuongDan = "/user-content/20401a19-080b-4983-9ccd-0799a15d8474.webp", MaSanPham = 6, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 15, 03, 39, 697, DateTimeKind.Utc).AddTicks(2322), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 40, DuongDan = "/user-content/cedcdac7-562a-438f-b3fe-a1e431b293f4.webp", MaSanPham = 6, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 04, 04, 895, DateTimeKind.Utc).AddTicks(8437), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 41, DuongDan = "/user-content/b587f7d9-8de0-4d9e-8213-4de24055b44a.webp", MaSanPham = 6, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 04, 17, 033, DateTimeKind.Utc).AddTicks(9597), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 42, DuongDan = "/user-content/44fa3c5a-b5f5-4305-8b23-7383fd6fb58d.webp", MaSanPham = 6, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 04, 32, 599, DateTimeKind.Utc).AddTicks(3383), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 43, DuongDan = "/user-content/227a8e30-60b5-4525-a3f7-efdb992698a1.png", MaSanPham = 7, Mota = "s", NgayTao = new DateTime(2025, 05, 25, 15, 06, 17, 950, DateTimeKind.Utc).AddTicks(9735), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 44, DuongDan = "/user-content/9ec0ce09-845c-4a5a-af69-ef0d816c757b.png", MaSanPham = 7, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 06, 25, 059, DateTimeKind.Utc).AddTicks(0381), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 45, DuongDan = "/user-content/28cb01e5-d934-454a-a105-1ed02dedfa36.png", MaSanPham = 7, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 06, 33, 076, DateTimeKind.Utc).AddTicks(7742), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 46, DuongDan = "/user-content/74155430-c217-4ea8-a79a-cf5557a1d245.png", MaSanPham = 7, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 06, 46, 588, DateTimeKind.Utc).AddTicks(7042), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 47, DuongDan = "/user-content/bc22666f-b6d2-4680-a449-354aebe6a431.png", MaSanPham = 7, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 07, 06, 031, DateTimeKind.Utc).AddTicks(9322), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 48, DuongDan = "/user-content/8d2f638d-2e8b-4456-9155-9ffb45b3eaf8.png", MaSanPham = 8, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 08, 14, 762, DateTimeKind.Utc).AddTicks(1710), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 49, DuongDan = "/user-content/a284f159-a24a-4bfa-a1a8-ea96db900d61.png", MaSanPham = 8, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 08, 31, 632, DateTimeKind.Utc).AddTicks(9623), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 50, DuongDan = "/user-content/88244490-1b9b-4147-a9a8-cc5dfbb9b581.png", MaSanPham = 8, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 08, 50, 075, DateTimeKind.Utc).AddTicks(4347), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 51, DuongDan = "/user-content/8e407540-b743-4ff1-95df-286736471de7.png", MaSanPham = 8, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 09, 00, 111, DateTimeKind.Utc).AddTicks(1204), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 52, DuongDan = "/user-content/3d27fb88-b296-4e2c-9c2a-eba908eafc76.webp", MaSanPham = 10, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 21, 27, 805, DateTimeKind.Utc).AddTicks(1149), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 54, DuongDan = "/user-content/a5960094-acad-4ea6-9c7c-80cb0d6e3afe.webp", MaSanPham = 10, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 23, 57, 107, DateTimeKind.Utc).AddTicks(7261), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 56, DuongDan = "/user-content/dd5a0800-f3e6-48d1-99a1-5f96bae82591.webp", MaSanPham = 10, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 24, 38, 790, DateTimeKind.Utc).AddTicks(5409), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 57, DuongDan = "/user-content/7dbf715b-f811-46df-be9c-ec466c4df33e.png", MaSanPham = 13, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 27, 20, 052, DateTimeKind.Utc).AddTicks(9913), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 58, DuongDan = "/user-content/5efd88f8-50db-4681-9e8e-7d31b4f85119.png", MaSanPham = 13, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 27, 28, 961, DateTimeKind.Utc).AddTicks(4938), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 59, DuongDan = "/user-content/8cc9c68b-86dd-48c6-a926-3bac4fed84ad.png", MaSanPham = 13, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 27, 42, 692, DateTimeKind.Utc).AddTicks(9113), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 60, DuongDan = "/user-content/0534e4e4-a1ef-4961-a137-bd825270cfb2.png", MaSanPham = 13, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 27, 58, 203, DateTimeKind.Utc).AddTicks(2257), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 61, DuongDan = "/user-content/84fc2b08-da8e-4d19-9f65-7920a3b47a04.png", MaSanPham = 13, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 28, 09, 213, DateTimeKind.Utc).AddTicks(8202), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 62, DuongDan = "/user-content/e9bd5ff4-c7c0-4c43-8a75-5f2a9eb0da16.png", MaSanPham = 14, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 29, 48, 114, DateTimeKind.Utc).AddTicks(9785), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 63, DuongDan = "/user-content/5fa677cd-e90c-4d0d-a33e-44ff34360895.png", MaSanPham = 14, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 29, 56, 719, DateTimeKind.Utc).AddTicks(2050), MaDanhGia = null, IsDefault = true },
                new HinhAnh { MaHinhAnh = 64, DuongDan = "/user-content/53f59bde-a338-431a-912a-e87fdc8b2e06.png", MaSanPham = 14, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 30, 08, 116, DateTimeKind.Utc).AddTicks(3458), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 65, DuongDan = "/user-content/6abb0d85-3e2d-4e14-806e-1a5bcb6b21d7.png", MaSanPham = 14, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 30, 19, 716, DateTimeKind.Utc).AddTicks(5824), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 66, DuongDan = "/user-content/5b931c1b-6850-4cc0-91e4-79b3ba882bbe.png", MaSanPham = 15, Mota = "Thumbnail Images", NgayTao = new DateTime(2025, 05, 25, 15, 32, 41, 018, DateTimeKind.Utc).AddTicks(7380), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 67, DuongDan = "/user-content/5e3de4f1-48b4-44bc-b6b5-4a1dfa03b377.png", MaSanPham = 15, Mota = "q", NgayTao = new DateTime(2025, 05, 25, 15, 32, 48, 998, DateTimeKind.Utc).AddTicks(2490), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 68, DuongDan = "/user-content/2689bfce-ebab-4e56-bbee-ec7ff84fbef9.png", MaSanPham = 15, Mota = "q", NgayTao = new DateTime(2025, 05, 25, 15, 33, 03, 277, DateTimeKind.Utc).AddTicks(5455), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 69, DuongDan = "/user-content/9185d88a-e602-40c7-85b1-5e4c4134f9d2.png", MaSanPham = 15, Mota = "a", NgayTao = new DateTime(2025, 05, 25, 15, 33, 20, 155, DateTimeKind.Utc).AddTicks(5206), MaDanhGia = null, IsDefault = false },
                new HinhAnh { MaHinhAnh = 70, DuongDan = "/user-content/8567fa7e-8e6f-41c5-8ca1-6c2a1fae9ce7.png", MaSanPham = 8, Mota = "k", NgayTao = new DateTime(2025, 05, 25, 21, 08, 31, 907, DateTimeKind.Utc).AddTicks(4647), MaDanhGia = null, IsDefault = true }
            );

            // Seed ProductInCategory
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory { MaSanPham = 1, MaDanhMuc = 1 },
                new ProductInCategory { MaSanPham = 2, MaDanhMuc = 2 },
                new ProductInCategory { MaSanPham = 3, MaDanhMuc = 2 },
                new ProductInCategory { MaSanPham = 4, MaDanhMuc = 2 },
                new ProductInCategory { MaSanPham = 5, MaDanhMuc = 2 },
                new ProductInCategory { MaSanPham = 6, MaDanhMuc = 4 },
                new ProductInCategory { MaSanPham = 7, MaDanhMuc = 3 },
                new ProductInCategory { MaSanPham = 8, MaDanhMuc = 3 },
                new ProductInCategory { MaSanPham = 10, MaDanhMuc = 4 },
                new ProductInCategory { MaSanPham = 13, MaDanhMuc = 1 },
                new ProductInCategory { MaSanPham = 14, MaDanhMuc = 1 },
                new ProductInCategory { MaSanPham = 15, MaDanhMuc = 1 }
            );

            // Seed SanPham
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham
                {
                    MaSanPham = 1,
                    TenSanPham = "Quần đùi chạy bộ nam tập thể thao ",
                    Gia = 150000.00M,
                    MoTa = "ĐẶC ĐIỂM NỔI BẬT\n– Quần chạy bộ siêu nhẹ chỉ từ 80g\n– Quần đùi nam tập thể thao Gymlab được thiết kế với công nghệ vải co giãn tốt. Cực kỳ nhẹ, tạo cảm giác mặc vô cùng thoải mái.\n– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc quần của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.\n– Cảm giác vải cực kỳ nhẹ và mềm, công nghệ thoát ẩm 1 chiều giúp cho chiếc quần cực kỳ nhanh khô.\n– Quần có thiết kế form 5 inch ngắn trên gối, xẻ 2 bên phù hợp tập luyện.\n– Thiết kế 2 đáy, tránh đường may dấu cộng (+) ở dưới đáy quần, đảm bảo được độ bền chắc qua tất cả các bài tập chân khó nhất.\n– Quần có màu xám in họa tiết chữ Gymlab giúp tạo điểm nhấn nổi bật.\n– Quần form ôm fit, phong cách năng động thích hợp mặc đi tập gym, chạy bộ, cardio, daily wear.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.",
                    KichThuoc = "L",
                    MauSac = "Đen",
                    SoLuongTon = 150,
                    NgayTao = new DateTime(2025, 05, 01, 00, 00, 00, 000, DateTimeKind.Utc),
                    NoiBat = true
                },
                new SanPham
                {
                    MaSanPham = 2,
                    TenSanPham = "ÁO TANK SÁT NÁCH NAM – ĐEN – SILVER LOGO",
                    Gia = 175000.00M,
                    MoTa = "Thông tin cơ bản:\n\n– Người mẫu cao 1m68, nặng 65kg mặc size M vừa đẹp.\n– Chiếc áo mang đến cảm giác rộng thoải mái và cực kỳ thoáng mát khi tập.\n– Thiết kế theo dạng áo Tank sát nách, tôn dáng vai rất tốt. Tạo cảm giác vai to hơn khi mặc, giúp tăng vẻ mạnh mẽ và nam tính.\n– Cảm giác vải cực kỳ mềm mượt, công nghệ thoát ẩm 1 chiều giúp cho chiếc áo cực kỳ nhanh khô.\n– Logo được in màu bạc phản quang nhẹ vô cùng tinh tế.\n\nĐược thiết kế phù hợp với:\n\n– Tập Gym, Chạy bộ, Cardio, Daily Wear.\n– Tập luyện trong nhà và ngoài trời.\n– Phù hợp với nhiệt độ thời tiết từ 20-40 độ C.",
                    KichThuoc = "L",
                    MauSac = "Xám",
                    SoLuongTon = 2498,
                    NgayTao = new DateTime(2025, 05, 01, 00, 00, 00, 000, DateTimeKind.Utc),
                    NoiBat = true
                },
                new SanPham
                {
                    MaSanPham = 3,
                    TenSanPham = "ÁO TẬP CÓ TAY NAM – XANH ĐEN – SILVER LOGO",
                    Gia = 150000.00M,
                    MoTa = "Đặc điểm nổi bật của áo công nghệ vải Activ-cool\n\n \n\nLần đầu tiên có 1 local brand đem đến Công nghệ vải đến từ Hàn Quốc với các tính năng vượt trội.\nÁo tập có tính năng: Co giãn, mềm mịn, mát mẻ, khử mùi, thoát mồ hôi cực nhanh, chống tia UV.\nĐảm bảo đem lại cảm giác mặc vô cùng thoải mái trong tất cả hoạt động hàng ngày, đặc biệt là trong hoạt động thể thao.\n \n\nThiết kế áo tập có tay co giãn của Gymlab\n\n \n\nĐội ngũ của Gymlab đã gửi rất nhiều tâm huyết vào dòng sản phẩm này, với tiêu chí thiết kế sản phẩm thoải mái khi tập luyện cũng như vượt trội về mặt thẩm mỹ.\n\n \n\nChiếc áo được may với thiết kế Raglan, tạo độ thẩm mỹ rất tốt cho người mặc, tạo cảm giác phần cầu vai và thân trên rộng hơn. Góp phần lớn vào việc tăng vẻ nam tính cho người mặc.\nChất liệu áo co giãn 4 chiều, mềm mỏng tạo cảm giác thoải mái không chỉ khi tập luyện, mà còn có thể mặc trong sinh hoạt hằng ngày. Đảm bảo khả năng khử mùi trong 48 giờ, bất chấp mọi thời tiết.\nHình in phản quang nhẹ giúp tăng tính thẩm mỹ của áo, lớp phản quang nhẹ không quá sáng, khiến cho người mặc giữ được sự lịch lãm đơn giản, không quá chói lóa.",
                    KichThuoc = "L",
                    MauSac = "Xanh Navi",
                    SoLuongTon = 100,
                    NgayTao = new DateTime(2025, 05, 01, 00, 00, 00, 000, DateTimeKind.Utc),
                    NoiBat = false
                },
                new SanPham
                {
                    MaSanPham = 4,
                    TenSanPham = "Áo Tập Gym Thể Thao Cho Nam – Xám – Silver Logo",
                    Gia = 250000.00M,
                    MoTa = "ĐẶC ĐIỂM NỔI BẬT\n– Áo thể thao tập gym nam Gymlab được thiết kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.\n– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc áo của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.\n– Áo form ôm fit, mang đến cảm giác vừa vặn và cực kỳ thoáng mát thích hợp mặc đi tập gym, thể thao.\n– Áo thiết kế tay ngắn đường may raglan (rắc lăng) tạo độ ôm tốt vào cầu vai. Giúp người mặc có cảm giác vai to và rộng hơn, tăng vẻ mạnh mẽ và nam tính của đàn ông.\n– Logo được in màu xám phản quang nhẹ vô cùng tinh tế.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.",
                    KichThuoc = "M",
                    MauSac = "Xanh nhạt",
                    SoLuongTon = 30,
                    NgayTao = new DateTime(2025, 05, 01, 00, 00, 00, 000, DateTimeKind.Utc),
                    NoiBat = false
                },
                new SanPham
                {
                    MaSanPham = 5,
                    TenSanPham = "Áo Thể Thao Nam GYMLAB Raglan Tay Ngắn Phối Màu Tay Áo",
                    Gia = 175000.00M,
                    MoTa = "ĐẶC ĐIỂM NỔI BẬT\n– Áo thể thao tập gym nam Gymlab được thiết kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.\n– Chất vải luôn đem lại cảm giác vô cùng mềm và nhẹ. Nhờ đặc tính kết hợp tuyệt vời của vải, chiếc áo của Gymlab cực kỳ nhanh thoát mồ hôi và loại trừ hầu hết mùi cơ thể.\n– Áo form ôm fit, mang đến cảm giác vừa vặn và cực kỳ thoáng mát thích hợp mặc đi tập gym, thể thao.\n– Áo thiết kế tay ngắn đường may raglan (rắc lăng) tạo độ ôm tốt vào cầu vai. Giúp người mặc có cảm giác vai to và rộng hơn, tăng vẻ mạnh mẽ và nam tính của đàn ông.\n– Logo được in màu xám phản quang nhẹ vô cùng tinh tế.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.\n\nHƯỚNG DẪN BẢO QUẢN\n– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.\n– Khi phơi nên lộn mặt trong của quần áo ra ngoài.\n– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.",
                    KichThuoc = "L",
                    MauSac = "Đen",
                    SoLuongTon = 250,
                    NgayTao = new DateTime(2025, 05, 01, 00, 00, 00, 000, DateTimeKind.Utc),
                    NoiBat = false
                },
                new SanPham
                {
                    MaSanPham = 6,
                    TenSanPham = "Bình Nước Tập Gym , Bình Lắc Thể Thao Có Con Lắc Lò Xo Tiện Lợi Myprotein 700ml",
                    Gia = 75000.00M,
                    MoTa = "ngon bổ rẻ",
                    KichThuoc = "L",
                    MauSac = "Đen",
                    SoLuongTon = 34,
                    NgayTao = new DateTime(0001, 01, 01, 00, 00, 00, 000, DateTimeKind.Utc),
                    NoiBat = true
                },
                new SanPham
                {
                    MaSanPham = 7,
                    TenSanPham = "Giày Nike Zoom Vapor Pro 2 HC ‘White’ DR6191-101",
                    Gia = 750000.00M,
                    MoTa = "Ngon rẻ bổ",
                    KichThuoc = "43",
                    MauSac = "Trắng",
                    SoLuongTon = 50,
                    NgayTao = new DateTime(2025, 05, 12, 18, 10, 30, 817, DateTimeKind.Utc).AddTicks(0801),
                    NoiBat = false
                },
                new SanPham
                {
                    MaSanPham = 8,
                    TenSanPham = "Giày Tennis Asics Court FF Novak ‘Cranberry White’ 1041A089-605",
                    Gia = 1200000.00M,
                    MoTa = "Rẻ bổ ngon",
                    KichThuoc = "42",
                    MauSac = "Đỏ",
                    SoLuongTon = 22,
                    NgayTao = new DateTime(2025, 05, 12, 18, 20, 27, 620, DateTimeKind.Utc).AddTicks(0550),
                    NoiBat = false
                },
                new SanPham
                {
                    MaSanPham = 10,
                    TenSanPham = "Khăn bông cotton",
                    Gia = 50000.00M,
                    MoTa = "ngon bổ re",
                    KichThuoc = "30x50",
                    MauSac = "Đen",
                    SoLuongTon = 150,
                    NgayTao = new DateTime(2025, 05, 13, 14, 51, 32, 015, DateTimeKind.Utc).AddTicks(8239),
                    NoiBat = false
                },
                new SanPham
                {
                    MaSanPham = 13,
                    TenSanPham = "Quần Jogger Túi Hộp Thể Thao Unisex ",
                    Gia = 175000.00M,
                    MoTa = "ĐẶC ĐIỂM NỔI BẬT\n– Trẻ trung, năng động với kiểu dáng Jogger thời thượng, quần Jogger nam lưng thun dây rút của Gymlab chắc chắn sẽ là must-have-item cho các tín đồ thời trang yêu thích phong cách đa ứng dụng.\n– Quần có thiết kế đơn giản nhưng hiện đại, kế với công nghệ vải Activ-cool đến từ Hàn Quốc. Vải được tăng tỉ lệ Spandex giúp tăng khả năng co giãn vượt trội.\n– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.\n– Thiết kế lưng thun phối dây rút cùng chi tiết bo ống, logo được in màu bạc phản quang nhẹ vô cùng tinh tế.\n– Quần jogger tập gym nam không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.\n– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.\n\nHƯỚNG DẪN BẢO QUẢN\n– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.\n– Khi phơi nên lộn mặt trong của quần áo ra ngoài.\n– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.",
                    KichThuoc = "L",
                    MauSac = "Đen",
                    SoLuongTon = 332,
                    NgayTao = new DateTime(2025, 05, 23, 14, 25, 41, 920, DateTimeKind.Utc).AddTicks(6926),
                    NoiBat = false
                },
                new SanPham
                {
                    MaSanPham = 14,
                    TenSanPham = "Quần short tập gym nam 2 lớp ",
                    Gia = 200000.00M,
                    MoTa = "ĐẶC ĐIỂM NỔI BẬT\n– Quần short tập gym nam 2 lớp là một sản phẩm thời trang dành cho những người yêu thích thể hình và sức khỏe.\n– Quần có thiết kế đơn giản nhưng hiện đại, với 2 lớp vải chất lượng cao, thoáng mát và co giãn tốt.\n– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.\n– Quần short tập gym nam 2 lớp không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.\n– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.\n\nHƯỚNG DẪN BẢO QUẢN\n– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.\n– Khi phơi nên lộn mặt trong của quần áo ra ngoài.\n– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.",
                    KichThuoc = "L",
                    MauSac = "Đen",
                    SoLuongTon = 123,
                    NgayTao = new DateTime(2025, 05, 25, 13, 53, 33, 552, DateTimeKind.Utc).AddTicks(7552),
                    NoiBat = false
                },
                new SanPham
                {
                    MaSanPham = 15,
                    TenSanPham = "Quần short tập gym nam 2 lớp",
                    Gia = 250000.00M,
                    MoTa = "ĐẶC ĐIỂM NỔI BẬT\n– Quần short tập gym nam 2 lớp là một sản phẩm thời trang dành cho những người yêu thích thể hình và sức khỏe.\n– Quần có thiết kế đơn giản nhưng hiện đại, với 2 lớp vải chất lượng cao, thoáng mát và co giãn tốt.\n– Quần có nhiều màu sắc và kích cỡ để bạn lựa chọn, phù hợp với mọi phong cách và dáng người.\n– Quần short tập gym nam 2 lớp không chỉ giúp bạn thoải mái khi tập luyện, mà còn tôn lên vẻ đẹp nam tính và khỏe khoắn của bạn.\n– Quần cũng rất dễ phối đồ bạn có thể kết hợp với áo thun, áo sơ mi hay áo khoác… Để tạo nên những bộ trang phục năng động và cá tính.\n– Sản phẩm được đảm bảo với quy trình sản xuất chất lượng với đường may chắc chắn, tỉ mỉ từng chi tiết.\n***Lưu ý: Màu sản phẩm có thể sẽ chênh lệch thực tế một phần nhỏ, do ảnh hưởng về độ lệch màu của ánh sáng nhưng vẫn đảm bảo chất lượng.\n\nHƯỚNG DẪN BẢO QUẢN\n– Không giặt rửa sản phẩm trực tiếp với chất tẩy rửa mạnh, sẽ gây phai màu và hư hại chất vải của sản phẩm.\n– Khi phơi nên lộn mặt trong của quần áo ra ngoài.\n– Tránh phơi đồ trực tiếp dưới nắng vì sẽ làm phai màu vải nhanh hơn.",
                    KichThuoc = "m",
                    MauSac = "Đen",
                    SoLuongTon = 31,
                    NgayTao = new DateTime(2025, 05, 25, 15, 32, 41, 018, DateTimeKind.Utc).AddTicks(6589),
                    NoiBat = false
                }
            );
        }
    }
}