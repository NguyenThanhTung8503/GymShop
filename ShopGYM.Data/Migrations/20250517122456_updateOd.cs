using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateOd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_MaSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_SanPham_SanPhamMaSanPham",
                table: "DonHang");

            migrationBuilder.DropIndex(
                name: "IX_DonHang_SanPhamMaSanPham",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "SanPhamMaSanPham",
                table: "DonHang");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_MaSanPham",
                table: "ChiTietDonHang",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_MaSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.AddColumn<int>(
                name: "SanPhamMaSanPham",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_SanPhamMaSanPham",
                table: "DonHang",
                column: "SanPhamMaSanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_MaSanPham",
                table: "ChiTietDonHang",
                column: "MaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_SanPham_SanPhamMaSanPham",
                table: "DonHang",
                column: "SanPhamMaSanPham",
                principalTable: "SanPham",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
