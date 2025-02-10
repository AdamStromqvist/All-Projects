using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOSU2_Laboration3.Migrations
{
    /// <inheritdoc />
    public partial class AddTestUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "NameEmployee", "Password", "Profession", "Specialization", "Username" },
                values: new object[] { 2, "Test User 2", "testpassword2", "Tester2", "Testing2", "testuser2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "NameEmployee", "Password", "Profession", "Specialization", "Username" },
                values: new object[] { 1, "Test User", "testpassword", "Tester", "Testing", "testuser" });
        }
    }
}
