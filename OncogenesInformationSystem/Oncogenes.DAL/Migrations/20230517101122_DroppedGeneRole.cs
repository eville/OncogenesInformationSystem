using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DroppedGeneRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleInCancer",
                table: "Oncogenes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleInCancer",
                table: "Oncogenes",
                type: "longtext",
                nullable: false);
        }
    }
}
