using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "MoTa", "Name", "NormalizedName" },
                values: new object[] { new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1"), null, "Quan Tri", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "DanhMuc",
                columns: new[] { "MaDanhMuc", "MoTa", "TenDanhMuc" },
                values: new object[,]
                {
                    { 1, "Quần các loại", "Quan" },
                    { 2, "Áo thời trang", "Ao" },
                    { 3, "Giày thể thao và thời trang", "Giay" },
                    { 4, "Phụ kiện thời trang", "PhuKien" }
                });

            migrationBuilder.InsertData(
                table: "NhaCungCap",
                columns: new[] { "MaNhaCungCap", "DiaChi", "Email", "SoDienThoai", "TenNhaCungCap" },
                values: new object[,]
                {
                    { 1, "123 Factory St, Hanoi", "abc@company.com", "0901234560", "Công ty TNHH May Mặc ABC" },
                    { 2, "456 Factory St, HCMC", "xyz@company.com", "0901234561", "Công ty Giày XYZ" },
                    { 3, "789 Factory St, Danang", "123@company.com", "0901234562", "Công ty Phụ Kiện 123" },
                    { 4, "321 Factory St, Hanoi", "def@company.com", "0901234563", "Công ty Thời Trang DEF" }
                });

            migrationBuilder.InsertData(
                table: "NhapHang",
                columns: new[] { "MaNhapHang", "GhiChu", "MaNhaCungCap", "NgayNhap", "TongTien" },
                values: new object[,]
                {
                    { 1, "Nhập lô quần jeans", 1, new DateTime(2025, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 5000000m },
                    { 2, "Nhập lô giày sneaker", 2, new DateTime(2025, 4, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 8000000m },
                    { 3, "Nhập lô phụ kiện", 3, new DateTime(2025, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 2000000m },
                    { 4, "Nhập lô áo thun", 4, new DateTime(2025, 4, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 6000000m }
                });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "MaSanPham", "Gia", "KichThuoc", "MaDanhMuc", "MauSac", "MoTa", "SoLuongTon", "TenSanPham" },
                values: new object[,]
                {
                    { 1, 350000m, "M", 1, "Xanh đậm", "Quần jeans nam phong cách", 50, "Quần Jeans Nam" },
                    { 2, 280000m, "S", 1, "Beige", "Quần kaki nữ thời trang", 40, "Quần Kaki Nữ" },
                    { 3, 150000m, "L", 2, "Trắng", "Áo thun nam cotton", 100, "Áo Thun Nam" },
                    { 4, 250000m, "M", 2, "Xanh nhạt", "Áo sơ mi nữ công sở", 30, "Áo Sơ Mi Nữ" },
                    { 5, 650000m, "L", 3, "Đen", "Giày sneaker nam thời trang", 25, "Giày Sneaker Nam" }
                });

            migrationBuilder.InsertData(
                table: "ChiTietNhapHang",
                columns: new[] { "MaChiTietNhapHang", "GiaNhap", "MaNhapHang", "MaSanPham", "SoLuong" },
                values: new object[,]
                {
                    { 1, 200000m, 1, 1, 50 },
                    { 2, 400000m, 2, 5, 30 },
                    { 3, 80000m, 3, 4, 100 },
                    { 4, 100000m, 4, 3, 150 }
                });

            migrationBuilder.InsertData(
                table: "HinhAnh",
                columns: new[] { "MaHinhAnh", "DuongDan", "MaDanhGia", "MaSanPham", "Mota", "NgayTao", "ThuTu" },
                values: new object[,]
                {
                    { 1, "/images/jeans.jpg", null, 1, "Hình quần jeans nam", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "/images/kaki.jpg", null, 2, "Hình quần kaki nữ", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "/images/tshirt.jpg", null, 3, "Hình áo thun nam", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "/images/shirt.jpg", null, 4, "Hình áo sơ mi nữ", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "/images/sneaker.jpg", null, 5, "Hình giày sneaker nam", new DateTime(2025, 3, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1"));

            migrationBuilder.DeleteData(
                table: "ChiTietNhapHang",
                keyColumn: "MaChiTietNhapHang",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChiTietNhapHang",
                keyColumn: "MaChiTietNhapHang",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChiTietNhapHang",
                keyColumn: "MaChiTietNhapHang",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChiTietNhapHang",
                keyColumn: "MaChiTietNhapHang",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NhapHang",
                keyColumn: "MaNhapHang",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NhapHang",
                keyColumn: "MaNhapHang",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NhapHang",
                keyColumn: "MaNhapHang",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NhapHang",
                keyColumn: "MaNhapHang",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNhaCungCap",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNhaCungCap",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNhaCungCap",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNhaCungCap",
                keyValue: 4);
        }
    }
}
