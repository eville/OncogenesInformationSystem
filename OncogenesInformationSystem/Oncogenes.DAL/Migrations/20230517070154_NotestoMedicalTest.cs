using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NotestoMedicalTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "MedicalTests",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "MedicalTests");
        }
    }
}
