using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOSU2_Laboration3.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientIDToMedicinePrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "MedicinePrescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "MedicinePrescriptions");
        }
    }
}
