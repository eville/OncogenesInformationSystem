using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TestingStatusRemoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestingStatus",
                table: "Activations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestingStatus",
                table: "Activations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
