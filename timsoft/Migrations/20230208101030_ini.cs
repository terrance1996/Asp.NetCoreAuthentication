using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timsoft.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRole", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "RH" },
                    { 3, "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "IdRole",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "IdRole",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "IdRole",
                keyValue: 3);
        }
    }
}
