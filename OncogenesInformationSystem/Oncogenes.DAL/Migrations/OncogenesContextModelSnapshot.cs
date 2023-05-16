﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oncogenes.DAL;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    [DbContext(typeof(OncogenesContext))]
    partial class OncogenesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DiseaseMedicalTests", b =>
                {
                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("MedicalTestId")
                        .HasColumnType("int");

                    b.HasKey("DiseaseId", "MedicalTestId");

                    b.HasIndex("MedicalTestId");

                    b.ToTable("DiseaseMedicalTests");
                });

            modelBuilder.Entity("DrugActivation", b =>
                {
                    b.Property<int>("ActivationId")
                        .HasColumnType("int");

                    b.Property<int>("DrugId")
                        .HasColumnType("int");

                    b.HasKey("ActivationId", "DrugId");

                    b.HasIndex("DrugId");

                    b.ToTable("DrugActivation");
                });

            modelBuilder.Entity("OncogeneResistanceToDrug", b =>
                {
                    b.Property<int>("DrugId")
                        .HasColumnType("int");

                    b.Property<int>("OncogeneId")
                        .HasColumnType("int");

                    b.HasKey("DrugId", "OncogeneId");

                    b.HasIndex("OncogeneId");

                    b.ToTable("OncogeneResistanceToDrug");
                });

            modelBuilder.Entity("Oncogenes.Domain.Activation", b =>
                {
                    b.Property<int>("ActivationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActionabilityRank")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DevelopmentStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<string>("DrugCombination")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MutationRemark")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OncogeneId")
                        .HasColumnType("int");

                    b.Property<string>("TestingRequired")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TestingStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TrialPrimaryCompletionDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ActivationId");

                    b.HasIndex("DiseaseId");

                    b.HasIndex("OncogeneId");

                    b.ToTable("Activations");
                });

            modelBuilder.Entity("Oncogenes.Domain.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("Oncogenes.Domain.DiseaseCode", b =>
                {
                    b.Property<int>("DiseaseCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CodeDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CodeLevel")
                        .HasColumnType("int");

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<string>("OrphaCode")
                        .HasColumnType("longtext");

                    b.HasKey("DiseaseCodeId");

                    b.HasIndex("DiseaseId");

                    b.ToTable("DiseaseCodes");
                });

            modelBuilder.Entity("Oncogenes.Domain.Drug", b =>
                {
                    b.Property<int>("DrugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ATC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GenericName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DrugId");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("Oncogenes.Domain.MedicalTest", b =>
                {
                    b.Property<int>("MedicalTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MedicalTestId");

                    b.ToTable("MedicalTests");
                });

            modelBuilder.Entity("Oncogenes.Domain.Oncogene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CancerSyndrome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TumorTypes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Oncogenes");
                });

            modelBuilder.Entity("OncogenesDiseases", b =>
                {
                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("OncogeneId")
                        .HasColumnType("int");

                    b.HasKey("DiseaseId", "OncogeneId");

                    b.HasIndex("OncogeneId");

                    b.ToTable("OncogenesDiseases");
                });

            modelBuilder.Entity("DiseaseMedicalTests", b =>
                {
                    b.HasOne("Oncogenes.Domain.Disease", null)
                        .WithMany()
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oncogenes.Domain.MedicalTest", null)
                        .WithMany()
                        .HasForeignKey("MedicalTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DrugActivation", b =>
                {
                    b.HasOne("Oncogenes.Domain.Activation", null)
                        .WithMany()
                        .HasForeignKey("ActivationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oncogenes.Domain.Drug", null)
                        .WithMany()
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OncogeneResistanceToDrug", b =>
                {
                    b.HasOne("Oncogenes.Domain.Drug", null)
                        .WithMany()
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oncogenes.Domain.Oncogene", null)
                        .WithMany()
                        .HasForeignKey("OncogeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Oncogenes.Domain.Activation", b =>
                {
                    b.HasOne("Oncogenes.Domain.Disease", "Disease")
                        .WithMany("Activations")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oncogenes.Domain.Oncogene", "Oncogene")
                        .WithMany("Activations")
                        .HasForeignKey("OncogeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("Oncogene");
                });

            modelBuilder.Entity("Oncogenes.Domain.DiseaseCode", b =>
                {
                    b.HasOne("Oncogenes.Domain.Disease", "Disease")
                        .WithMany("DiseaseCodes")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("OncogenesDiseases", b =>
                {
                    b.HasOne("Oncogenes.Domain.Disease", null)
                        .WithMany()
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oncogenes.Domain.Oncogene", null)
                        .WithMany()
                        .HasForeignKey("OncogeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Oncogenes.Domain.Disease", b =>
                {
                    b.Navigation("Activations");

                    b.Navigation("DiseaseCodes");
                });

            modelBuilder.Entity("Oncogenes.Domain.Oncogene", b =>
                {
                    b.Navigation("Activations");
                });
#pragma warning restore 612, 618
        }
    }
}
