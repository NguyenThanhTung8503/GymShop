using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThuTu",
                table: "HinhAnh");

            migrationBuilder.AlterColumn<string>(
                name: "MauSac",
                table: "SanPham",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KichThuoc",
                table: "SanPham",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "HinhAnh",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 1,
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 2,
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 3,
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 4,
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 5,
                column: "IsDefault",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "HinhAnh");

            migrationBuilder.AlterColumn<string>(
                name: "MauSac",
                table: "SanPham",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "KichThuoc",
                table: "SanPham",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ThuTu",
                table: "HinhAnh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 1,
                column: "ThuTu",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 2,
                column: "ThuTu",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 3,
                column: "ThuTu",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 4,
                column: "ThuTu",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HinhAnh",
                keyColumn: "MaHinhAnh",
                keyValue: 5,
                column: "ThuTu",
                value: 1);
        }
    }
}
