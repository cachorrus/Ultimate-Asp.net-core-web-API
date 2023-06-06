using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "0c1014c8-28ff-4d9b-b107-0987fb5e71cb");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "57dc3cd8-d529-4d43-955c-95eacb541047");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "b004df7c-45ea-4d17-9e63-9991116cf4ec", "6c7a5286-8453-4ba0-99c4-676dabfb1290", "Administrator", "ADMINISTRATOR" },
            //        { "e6f3c7f7-efd2-4775-8d35-c2436d1fc6ca", "76ba0ce7-f7f4-4fb9-85f4-78c32015c131", "Manager", "MANAGER" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "b004df7c-45ea-4d17-9e63-9991116cf4ec");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "e6f3c7f7-efd2-4775-8d35-c2436d1fc6ca");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "0c1014c8-28ff-4d9b-b107-0987fb5e71cb", "0ce66841-860e-4d50-a437-ddf415a653a4", "Administrator", "ADMINISTRATOR" },
            //        { "57dc3cd8-d529-4d43-955c-95eacb541047", "389f5205-6cb4-4252-ab35-e985f4157600", "Manager", "MANAGER" }
            //    });
        }
    }
}
