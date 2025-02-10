using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOSU2_Laboration3.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentsToPrescriptionsAndAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompatibilityComment",
                table: "MedicinePrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "DoctorAppointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompatibilityComment",
                table: "MedicinePrescriptions");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "DoctorAppointments");
        }
    }
}
