using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1"), new Guid("90b411be-a570-4839-8f59-492edcc9520d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8e15262e-8583-4c49-86be-cef2bf4345d1"), new Guid("90b411be-a570-4839-8f59-492edcc9520d") });
        }
    }
}
