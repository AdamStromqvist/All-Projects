using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektOOSU2_Test.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "NameEmployee", "Password", "Profession", "Specialization", "Username" },
                values: new object[] { 1, "Test User", "testpassword", "Tester", "Testing", "testuser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
