using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DiseaseCodeUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DiseaseCodes",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseCodes_Code",
                table: "DiseaseCodes",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DiseaseCodes_Code",
                table: "DiseaseCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "DiseaseCodes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
