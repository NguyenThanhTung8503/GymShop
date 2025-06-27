using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class abc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "NoiBat",
                table: "SanPham",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNguoiNhan",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SDT",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DiaChiGiaoHang",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PhuongThucThanhToan",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 1,
                column: "NoiBat",
                value: false);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 2,
                column: "NoiBat",
                value: false);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 3,
                column: "NoiBat",
                value: false);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 4,
                column: "NoiBat",
                value: false);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 5,
                column: "NoiBat",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhuongThucThanhToan",
                table: "DonHang");

            migrationBuilder.AlterColumn<bool>(
                name: "NoiBat",
                table: "SanPham",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "TenNguoiNhan",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SDT",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChiGiaoHang",
                table: "DonHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 1,
                column: "NoiBat",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 2,
                column: "NoiBat",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 3,
                column: "NoiBat",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 4,
                column: "NoiBat",
                value: null);

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 5,
                column: "NoiBat",
                value: null);
        }
    }
}
