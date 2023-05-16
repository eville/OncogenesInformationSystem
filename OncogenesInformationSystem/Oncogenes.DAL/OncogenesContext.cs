using Microsoft.EntityFrameworkCore;
using Oncogenes.Domain;

namespace Oncogenes.DAL
{
    public class OncogenesContext : DbContext
    {
        public OncogenesContext(DbContextOptions<OncogenesContext> options) : base(options)
        {
        }

        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiseaseCode> DiseaseCodes { get; set; }

        public DbSet<Oncogene> Oncogenes { get; set; }

        public DbSet<Drug> Drugs { get; set; }

        public DbSet<Activation> Activations { get; set; }

        public DbSet<MedicalTest> MedicalTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Oncogene>()
                .HasMany(o => o.Diseases)
                .WithMany(d => d.Oncogenes)
                 .UsingEntity<Dictionary<string, object>>(
                    "OncogenesDiseases",
                    j => j.HasOne<Disease>().WithMany().HasForeignKey("DiseaseId"),
                    j => j.HasOne<Oncogene>().WithMany().HasForeignKey("OncogeneId")
            );

            modelBuilder.Entity<Activation>()
                .HasOne(a => a.Oncogene)
                .WithMany(o => o.Activations)
                .HasForeignKey(a => a.OncogeneId);

            modelBuilder.Entity<Activation>()
                .HasOne(a => a.Disease)
                .WithMany(d => d.Activations)
                .HasForeignKey(a => a.DiseaseId);

            modelBuilder.Entity<Activation>()
                .HasMany(a => a.Drugs)
                .WithMany(d => d.Activations)
                 .UsingEntity<Dictionary<string, object>>(
                    "DrugActivation",
                    j => j.HasOne<Drug>().WithMany().HasForeignKey("DrugId"),
                    j => j.HasOne<Activation>().WithMany().HasForeignKey("ActivationId")
                );

            modelBuilder.Entity<Oncogene>()
               .HasMany(o => o.Drugs)
               .WithMany(d => d.Oncogenes)
                    .UsingEntity<Dictionary<string, object>>(
                       "OncogeneResistanceToDrug",
                       j => j.HasOne<Drug>().WithMany().HasForeignKey("DrugId"),
                       j => j.HasOne<Oncogene>().WithMany().HasForeignKey("OncogeneId")
               );

            modelBuilder.Entity<Disease>()
            .HasMany(d => d.DiseaseCodes)
            .WithOne(dc => dc.Disease)
            .HasForeignKey(dc => dc.DiseaseId);


            modelBuilder.Entity<MedicalTest>()
                .HasMany(m => m.Diseases)
                .WithMany(d => d.MedicalTests)
                .UsingEntity<Dictionary<string, object>>(
                    "DiseaseMedicalTests",
                    j => j.HasOne<Disease>().WithMany().HasForeignKey("DiseaseId"),
                    j => j.HasOne<MedicalTest>().WithMany().HasForeignKey("MedicalTestId")
                );

        }
    }
}
