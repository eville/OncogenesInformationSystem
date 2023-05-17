﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oncogenes.DAL;

#nullable disable

namespace Oncogenes.DAL.Migrations
{
    [DbContext(typeof(OncogenesContext))]
    [Migration("20230517103156_OptionalColumnsGene")]
    partial class OptionalColumnsGene
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("DiseaseTreatments", b =>
                {
                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int");

                    b.HasKey("DiseaseId", "TreatmentId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("DiseaseTreatments");
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

                    b.Property<int?>("CompletionStatus")
                        .HasColumnType("int");

                    b.Property<int?>("ControlNumber")
                        .HasColumnType("int");

                    b.Property<string>("ControlTreatment")
                        .HasColumnType("longtext");

                    b.Property<int>("DevelopmentStatus")
                        .HasColumnType("int");

                    b.Property<int?>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("LastUpdated")
                        .HasColumnType("date");

                    b.Property<string>("MutationRemark")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("NumberOfPatients")
                        .HasColumnType("int");

                    b.Property<int>("OncogeneId")
                        .HasColumnType("int");

                    b.Property<string>("TestingRequired")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TreatedNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("TrialPrimaryCompletionDate")
                        .HasColumnType("date");

                    b.Property<int?>("TrialStatus")
                        .HasColumnType("int");

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

                    b.Property<string>("GenericDrugName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DrugId");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("Oncogenes.Domain.Gene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CancerSyndrome")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TumorTypes")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Oncogenes");
                });

            modelBuilder.Entity("Oncogenes.Domain.MedicalTest", b =>
                {
                    b.Property<int>("MedicalTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.HasKey("MedicalTestId");

                    b.ToTable("MedicalTests");
                });

            modelBuilder.Entity("Oncogenes.Domain.Treatment", b =>
                {
                    b.Property<int>("TreatmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TreatmentId");

                    b.ToTable("Treatment");
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

            modelBuilder.Entity("DiseaseTreatments", b =>
                {
                    b.HasOne("Oncogenes.Domain.Disease", null)
                        .WithMany()
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oncogenes.Domain.Treatment", null)
                        .WithMany()
                        .HasForeignKey("TreatmentId")
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

                    b.HasOne("Oncogenes.Domain.Gene", null)
                        .WithMany()
                        .HasForeignKey("OncogeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Oncogenes.Domain.Activation", b =>
                {
                    b.HasOne("Oncogenes.Domain.Disease", null)
                        .WithMany("Activations")
                        .HasForeignKey("DiseaseId");

                    b.HasOne("Oncogenes.Domain.Gene", "Oncogene")
                        .WithMany("Activations")
                        .HasForeignKey("OncogeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.HasOne("Oncogenes.Domain.Gene", null)
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

            modelBuilder.Entity("Oncogenes.Domain.Gene", b =>
                {
                    b.Navigation("Activations");
                });
#pragma warning restore 612, 618
        }
    }
}