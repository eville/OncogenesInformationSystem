using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRelationshipOfDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseCodes_Diseases_DiseaseId",
                table: "DiseaseCodes");

            migrationBuilder.DropIndex(
                name: "IX_DiseaseCodes_DiseaseId",
                table: "DiseaseCodes");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "DiseaseCodes");

            migrationBuilder.CreateTable(
                name: "DiseasesToCodes",
                columns: table => new
                {
                    DiseaseCodesDiseaseCodeId = table.Column<int>(type: "int", nullable: false),
                    DiseasesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseasesToCodes", x => new { x.DiseaseCodesDiseaseCodeId, x.DiseasesId });
                    table.ForeignKey(
                        name: "FK_DiseasesToCodes_DiseaseCodes_DiseaseCodesDiseaseCodeId",
                        column: x => x.DiseaseCodesDiseaseCodeId,
                        principalTable: "DiseaseCodes",
                        principalColumn: "DiseaseCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseasesToCodes_Diseases_DiseasesId",
                        column: x => x.DiseasesId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DiseasesToCodes_DiseasesId",
                table: "DiseasesToCodes",
                column: "DiseasesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseasesToCodes");

            migrationBuilder.AddColumn<int>(
                name: "DiseaseId",
                table: "DiseaseCodes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseCodes_DiseaseId",
                table: "DiseaseCodes",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseCodes_Diseases_DiseaseId",
                table: "DiseaseCodes",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id");
        }
    }
}
