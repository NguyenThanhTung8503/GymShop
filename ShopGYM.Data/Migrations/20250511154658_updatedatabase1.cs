using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoiBat",
                table: "SanPham",
                type: "bit",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoiBat",
                table: "SanPham");
        }
    }
}
