using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("90b411be-a570-4839-8f59-492edcc9520d"), 0, "1f2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d", new DateTime(2003, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyenthanhutng0168I@gmail.com", true, "Nguyen", "Tung", false, null, "Nguyenthanhutng0168I@gmail.com", "admin", "AQAAAAIAAYagAAAAEM46oTWgZoplJc03cruZtbZl0U+oFphoPy/WIUKRg7ddeIhiiLck/8cFrJw6UnM+MQ==", null, false, "", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("90b411be-a570-4839-8f59-492edcc9520d"));
        }
    }
}
