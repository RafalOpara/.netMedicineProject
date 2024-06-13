using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationWithRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_DoctorId",
                table: "prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_medicines_PrescriptionId",
                table: "medicines",
                column: "PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicines_prescriptions_PrescriptionId",
                table: "medicines",
                column: "PrescriptionId",
                principalTable: "prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptions_doctors_DoctorId",
                table: "prescriptions",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicines_prescriptions_PrescriptionId",
                table: "medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptions_doctors_DoctorId",
                table: "prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_prescriptions_DoctorId",
                table: "prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_medicines_PrescriptionId",
                table: "medicines");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "medicines");
        }
    }
}
