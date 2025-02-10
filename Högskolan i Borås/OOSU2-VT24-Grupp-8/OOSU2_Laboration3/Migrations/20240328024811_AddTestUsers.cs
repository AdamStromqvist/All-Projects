using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOSU2_Laboration3.Migrations
{
    /// <inheritdoc />
    public partial class AddTestUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "NameEmployee", "Password", "Profession", "Specialization", "Username" },
                values: new object[] { 1, "Test User 1", "testpassword1", "Tester1", "Testing1", "testuser1" });
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
