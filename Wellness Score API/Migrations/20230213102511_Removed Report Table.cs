using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessScoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovedReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Diagnoses_DiagnosisId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Reports_ReportId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ReportId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "WellnessScore",
                table: "Diagnoses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Diagnoses_DiagnosisId",
                table: "Customers",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Diagnoses_DiagnosisId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "WellnessScore",
                table: "Diagnoses");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anaemia = table.Column<bool>(type: "bit", nullable: false),
                    Cardiac = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Diabetic = table.Column<bool>(type: "bit", nullable: false),
                    Kidney = table.Column<bool>(type: "bit", nullable: false),
                    Obese = table.Column<bool>(type: "bit", nullable: false),
                    WellnessScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ReportId",
                table: "Customers",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Diagnoses_DiagnosisId",
                table: "Customers",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Reports_ReportId",
                table: "Customers",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
