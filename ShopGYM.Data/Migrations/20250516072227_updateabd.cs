using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateabd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "ChiTietNhapHang");

            migrationBuilder.DropTable(
                name: "NhapHang");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropColumn(
                name: "PhuongThucThanhToan",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "DonHang");

            migrationBuilder.AddColumn<decimal>(
                name: "Gia",
                table: "GioHang",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaBan",
                table: "DonHang",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaSanPham",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SanPhamMaSanPham",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_SanPhamMaSanPham",
                table: "DonHang",
                column: "SanPhamMaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_SanPham_SanPhamMaSanPham",
                table: "DonHang",
                column: "SanPhamMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_SanPham_SanPhamMaSanPham",
                table: "DonHang");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_SanPhamMaSanPham",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "GioHang");

            migrationBuilder.DropColumn(
                name: "GiaBan",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "MaSanPham",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "SanPhamMaSanPham",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "DonHang");

            migrationBuilder.AddColumn<string>(
                name: "PhuongThucThanhToan",
                table: "DonHang",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "DonHang",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    MaChiTietDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonHang = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    GiaBan = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => x.MaChiTietDonHang);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_DonHang_MaDonHang",
                        column: x => x.MaDonHang,
                        principalTable: "DonHang",
                        principalColumn: "MaDonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    MaNhaCungCap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.MaNhaCungCap);
                });

            migrationBuilder.CreateTable(
                name: "NhapHang",
                columns: table => new
                {
                    MaNhapHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhaCungCap = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapHang", x => x.MaNhapHang);
                    table.ForeignKey(
                        name: "FK_NhapHang_NhaCungCap_MaNhaCungCap",
                        column: x => x.MaNhaCungCap,
                        principalTable: "NhaCungCap",
                        principalColumn: "MaNhaCungCap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhapHang",
                columns: table => new
                {
                    MaChiTietNhapHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhapHang = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhapHang", x => x.MaChiTietNhapHang);
                    table.ForeignKey(
                        name: "FK_ChiTietNhapHang_NhapHang_MaNhapHang",
                        column: x => x.MaNhapHang,
                        principalTable: "NhapHang",
                        principalColumn: "MaNhapHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNhapHang_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
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
                table: "ChiTietNhapHang",
                columns: new[] { "MaChiTietNhapHang", "GiaNhap", "MaNhapHang", "MaSanPham", "SoLuong" },
                values: new object[,]
                {
                    { 1, 200000m, 1, 1, 50 },
                    { 2, 400000m, 2, 5, 30 },
                    { 3, 80000m, 3, 4, 100 },
                    { 4, 100000m, 4, 3, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaDonHang",
                table: "ChiTietDonHang",
                column: "MaDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaSanPham",
                table: "ChiTietDonHang",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapHang_MaNhapHang",
                table: "ChiTietNhapHang",
                column: "MaNhapHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapHang_MaSanPham",
                table: "ChiTietNhapHang",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_NhapHang_MaNhaCungCap",
                table: "NhapHang",
                column: "MaNhaCungCap");
        }
    }
}
