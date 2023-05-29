using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c1014c8-28ff-4d9b-b107-0987fb5e71cb", "0ce66841-860e-4d50-a437-ddf415a653a4", "Administrator", "ADMINISTRATOR" },
                    { "57dc3cd8-d529-4d43-955c-95eacb541047", "389f5205-6cb4-4252-ab35-e985f4157600", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c1014c8-28ff-4d9b-b107-0987fb5e71cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57dc3cd8-d529-4d43-955c-95eacb541047");
        }
    }
}
