using System;
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
                name: "DiseaseCodes",
                columns: table => new
                {
                    DiseaseCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DiseaseClassificator = table.Column<string>(type: "longtext", nullable: false),
                    CodeType = table.Column<int>(type: "int", nullable: false),
                    CodeDescription = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseCodes", x => x.DiseaseCodeId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GenericDrugName = table.Column<string>(type: "longtext", nullable: false)
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
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
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
                    CancerSyndrome = table.Column<string>(type: "longtext", nullable: true),
                    TumorTypes = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oncogenes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.TreatmentId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiseaseDiseaseCodes",
                columns: table => new
                {
                    DiseaseCodeId = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseDiseaseCodes", x => new { x.DiseaseCodeId, x.DiseaseId });
                    table.ForeignKey(
                        name: "FK_DiseaseDiseaseCodes_DiseaseCodes_DiseaseCodeId",
                        column: x => x.DiseaseCodeId,
                        principalTable: "DiseaseCodes",
                        principalColumn: "DiseaseCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseDiseaseCodes_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiseaseMedicalTest",
                columns: table => new
                {
                    DiseasesDiseaseId = table.Column<int>(type: "int", nullable: false),
                    MedicalTestsMedicalTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseMedicalTest", x => new { x.DiseasesDiseaseId, x.MedicalTestsMedicalTestId });
                    table.ForeignKey(
                        name: "FK_DiseaseMedicalTest_Diseases_DiseasesDiseaseId",
                        column: x => x.DiseasesDiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseMedicalTest_MedicalTests_MedicalTestsMedicalTestId",
                        column: x => x.MedicalTestsMedicalTestId,
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
                    MutationRemark = table.Column<string>(type: "longtext", nullable: false),
                    ActionabilityRank = table.Column<string>(type: "longtext", nullable: false),
                    DevelopmentStatus = table.Column<int>(type: "int", nullable: false),
                    TestingRequired = table.Column<string>(type: "longtext", nullable: false),
                    TrialPrimaryCompletionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TrialStatus = table.Column<int>(type: "int", nullable: true),
                    CompletionStatus = table.Column<int>(type: "int", nullable: true),
                    Info = table.Column<string>(type: "longtext", nullable: true),
                    NumberOfPatients = table.Column<int>(type: "int", nullable: true),
                    TreatedNumber = table.Column<int>(type: "int", nullable: true),
                    ControlNumber = table.Column<int>(type: "int", nullable: true),
                    ControlTreatment = table.Column<string>(type: "longtext", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DiseaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activations", x => x.ActivationId);
                    table.ForeignKey(
                        name: "FK_Activations_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId");
                    table.ForeignKey(
                        name: "FK_Activations_Oncogenes_OncogeneId",
                        column: x => x.OncogeneId,
                        principalTable: "Oncogenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiseaseGene",
                columns: table => new
                {
                    DiseasesDiseaseId = table.Column<int>(type: "int", nullable: false),
                    OncogenesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseGene", x => new { x.DiseasesDiseaseId, x.OncogenesId });
                    table.ForeignKey(
                        name: "FK_DiseaseGene_Diseases_DiseasesDiseaseId",
                        column: x => x.DiseasesDiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseGene_Oncogenes_OncogenesId",
                        column: x => x.OncogenesId,
                        principalTable: "Oncogenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DrugGene",
                columns: table => new
                {
                    DrugsDrugId = table.Column<int>(type: "int", nullable: false),
                    OncogenesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugGene", x => new { x.DrugsDrugId, x.OncogenesId });
                    table.ForeignKey(
                        name: "FK_DrugGene_Drugs_DrugsDrugId",
                        column: x => x.DrugsDrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugGene_Oncogenes_OncogenesId",
                        column: x => x.OncogenesId,
                        principalTable: "Oncogenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiseaseTreatment",
                columns: table => new
                {
                    DiseasesDiseaseId = table.Column<int>(type: "int", nullable: false),
                    TreatmentsTreatmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseTreatment", x => new { x.DiseasesDiseaseId, x.TreatmentsTreatmentId });
                    table.ForeignKey(
                        name: "FK_DiseaseTreatment_Diseases_DiseasesDiseaseId",
                        column: x => x.DiseasesDiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiseaseTreatment_Treatments_TreatmentsTreatmentId",
                        column: x => x.TreatmentsTreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "TreatmentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActivationDrug",
                columns: table => new
                {
                    ActivationsActivationId = table.Column<int>(type: "int", nullable: false),
                    DrugsDrugId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationDrug", x => new { x.ActivationsActivationId, x.DrugsDrugId });
                    table.ForeignKey(
                        name: "FK_ActivationDrug_Activations_ActivationsActivationId",
                        column: x => x.ActivationsActivationId,
                        principalTable: "Activations",
                        principalColumn: "ActivationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivationDrug_Drugs_DrugsDrugId",
                        column: x => x.DrugsDrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ActivationDrug_DrugsDrugId",
                table: "ActivationDrug",
                column: "DrugsDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Activations_DiseaseId",
                table: "Activations",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Activations_OncogeneId",
                table: "Activations",
                column: "OncogeneId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseDiseaseCodes_DiseaseId",
                table: "DiseaseDiseaseCodes",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseGene_OncogenesId",
                table: "DiseaseGene",
                column: "OncogenesId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseMedicalTest_MedicalTestsMedicalTestId",
                table: "DiseaseMedicalTest",
                column: "MedicalTestsMedicalTestId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseTreatment_TreatmentsTreatmentId",
                table: "DiseaseTreatment",
                column: "TreatmentsTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugGene_OncogenesId",
                table: "DrugGene",
                column: "OncogenesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationDrug");

            migrationBuilder.DropTable(
                name: "DiseaseDiseaseCodes");

            migrationBuilder.DropTable(
                name: "DiseaseGene");

            migrationBuilder.DropTable(
                name: "DiseaseMedicalTest");

            migrationBuilder.DropTable(
                name: "DiseaseTreatment");

            migrationBuilder.DropTable(
                name: "DrugGene");

            migrationBuilder.DropTable(
                name: "Activations");

            migrationBuilder.DropTable(
                name: "DiseaseCodes");

            migrationBuilder.DropTable(
                name: "MedicalTests");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Oncogenes");
        }
    }
}
