using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Code = table.Column<string>(type: "longtext", nullable: false),
                    CodeLevel = table.Column<int>(type: "int", nullable: false),
                    OrphaCode = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ATC = table.Column<string>(type: "longtext", nullable: false),
                    GenericName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalTests",
                columns: table => new
                {
                    MedicalTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalTests", x => x.MedicalTestId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Oncogenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CancerSyndrome = table.Column<string>(type: "longtext", nullable: false),
                    TumorTypes = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oncogenes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiseaseMedicalTests",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    MedicalTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseMedicalTests", x => new { x.DiseaseId, x.MedicalTestId });
                    table.ForeignKey(
                        name: "FK_DiseaseMedicalTests_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseMedicalTests_MedicalTests_MedicalTestId",
                        column: x => x.MedicalTestId,
                        principalTable: "MedicalTests",
                        principalColumn: "MedicalTestId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Activations",
                columns: table => new
                {
                    ActivationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OncogeneId = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    MutationRemark = table.Column<string>(type: "longtext", nullable: false),
                    DrugCombination = table.Column<string>(type: "longtext", nullable: false),
                    ActionabilityRank = table.Column<string>(type: "longtext", nullable: false),
                    DevelopmentStatus = table.Column<string>(type: "longtext", nullable: false),
                    TestingRequired = table.Column<string>(type: "longtext", nullable: false),
                    TestingStatus = table.Column<string>(type: "longtext", nullable: false),
                    TrialPrimaryCompletionDate = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activations", x => x.ActivationId);
                    table.ForeignKey(
                        name: "FK_Activations_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activations_Oncogenes_OncogeneId",
                        column: x => x.OncogeneId,
                        principalTable: "Oncogenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "OncogenesDiseases",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    OncogeneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OncogenesDiseases", x => new { x.DiseaseId, x.OncogeneId });
                    table.ForeignKey(
                        name: "FK_OncogenesDiseases_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OncogenesDiseases_Oncogenes_OncogeneId",
                        column: x => x.OncogeneId,
                        principalTable: "Oncogenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DrugActivation",
                columns: table => new
                {
                    ActivationId = table.Column<int>(type: "int", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugActivation", x => new { x.ActivationId, x.DrugId });
                    table.ForeignKey(
                        name: "FK_DrugActivation_Activations_ActivationId",
                        column: x => x.ActivationId,
                        principalTable: "Activations",
                        principalColumn: "ActivationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugActivation_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Activations_DiseaseId",
                table: "Activations",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Activations_OncogeneId",
                table: "Activations",
                column: "OncogeneId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseMedicalTests_MedicalTestId",
                table: "DiseaseMedicalTests",
                column: "MedicalTestId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugActivation_DrugId",
                table: "DrugActivation",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_OncogeneDrug_OncogeneId",
                table: "OncogeneDrug",
                column: "OncogeneId");

            migrationBuilder.CreateIndex(
                name: "IX_OncogenesDiseases_OncogeneId",
                table: "OncogenesDiseases",
                column: "OncogeneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseMedicalTests");

            migrationBuilder.DropTable(
                name: "DrugActivation");

            migrationBuilder.DropTable(
                name: "OncogeneDrug");

            migrationBuilder.DropTable(
                name: "OncogenesDiseases");

            migrationBuilder.DropTable(
                name: "MedicalTests");

            migrationBuilder.DropTable(
                name: "Activations");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Oncogenes");
        }
    }
}
