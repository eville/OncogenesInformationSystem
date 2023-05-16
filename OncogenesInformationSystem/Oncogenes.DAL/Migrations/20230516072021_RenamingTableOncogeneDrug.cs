using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamingTableOncogeneDrug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OncogeneDrug");

            migrationBuilder.CreateTable(
                name: "OncogeneResistanceToDrug",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    OncogeneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OncogeneResistanceToDrug", x => new { x.DrugId, x.OncogeneId });
                    table.ForeignKey(
                        name: "FK_OncogeneResistanceToDrug_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OncogeneResistanceToDrug_Oncogenes_OncogeneId",
                        column: x => x.OncogeneId,
                        principalTable: "Oncogenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OncogeneResistanceToDrug_OncogeneId",
                table: "OncogeneResistanceToDrug",
                column: "OncogeneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OncogeneResistanceToDrug");

            migrationBuilder.CreateTable(
                name: "OncogeneDrug",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    OncogeneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OncogeneDrug", x => new { x.DrugId, x.OncogeneId });
                    table.ForeignKey(
                        name: "FK_OncogeneDrug_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OncogeneDrug_Oncogenes_OncogeneId",
                        column: x => x.OncogeneId,
                        principalTable: "Oncogenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OncogeneDrug_OncogeneId",
                table: "OncogeneDrug",
                column: "OncogeneId");
        }
    }
}
