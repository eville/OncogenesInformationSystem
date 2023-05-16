using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedDiseaseCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "CodeLevel",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "OrphaCode",
                table: "Diseases");

            migrationBuilder.CreateTable(
                name: "DiseaseCode",
                columns: table => new
                {
                    CodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "longtext", nullable: false),
                    CodeDescription = table.Column<string>(type: "longtext", nullable: false),
                    CodeLevel = table.Column<int>(type: "int", nullable: false),
                    OrphaCode = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseCode", x => x.CodeId);
                    table.ForeignKey(
                        name: "FK_DiseaseCode_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseCode_DiseaseId",
                table: "DiseaseCode",
                column: "DiseaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseCode");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Diseases",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "CodeLevel",
                table: "Diseases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OrphaCode",
                table: "Diseases",
                type: "longtext",
                nullable: true);
        }
    }
}
