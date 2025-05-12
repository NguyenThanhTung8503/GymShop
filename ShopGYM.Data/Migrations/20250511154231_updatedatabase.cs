using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "SanPham",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 3,
                column: "NgayTao",
                value: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 4,
                column: "NgayTao",
                value: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "MaSanPham",
                keyValue: 5,
                column: "NgayTao",
                value: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "SanPham");
        }
    }
}
