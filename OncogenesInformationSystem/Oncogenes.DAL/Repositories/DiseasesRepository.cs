using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oncogenes.Domain;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;

namespace Oncogenes.DAL.Repository
{
    public class DiseasesRepository : IDiseasesRepository
    {
        private readonly ILogger logger;

        private readonly OncogenesContext appDbContext;
        public DiseasesRepository(ILogger<DiseasesRepository> logger, OncogenesContext appDbContext)
        {
            this.logger = logger;
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Disease>> GetAllDiseases()
        {
            return await appDbContext.Diseases
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Disease?> GetDiseaseById(int id)
        {
            return await appDbContext.Diseases
                .Include(d => d.DiseaseCodes)
                //.Include(d => d.MedicalTests)
                //.Include(d => d.Treatments)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.DiseaseId == id);
        }

        public async Task<Disease> AddDiseaseAsync(Disease disease)
        {
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;

            var existingDisease = appDbContext.Diseases
            .AsEnumerable().FirstOrDefault(d => compareInfo.Compare(d.Name, disease.Name, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0);
            
            if (existingDisease != null)
            {
                throw new Exception("Tokiu pavadinimu liga jau yra sistemoje.");
            }
            else
            {
                await appDbContext.Diseases.AddAsync(disease);
                await appDbContext.SaveChangesAsync();
                return disease;
            }     
        }

        public async Task DeleteAsync(Disease disease)
        {
            if (disease == null)
            {
                throw new ArgumentNullException(nameof(disease));
            }

            appDbContext.Diseases.Remove(disease);
            await appDbContext.SaveChangesAsync();
        }

        //todo: refactor method
        public async Task<Disease> UpdateDiseaseAsync(Disease disease)
        {

            try
            {
                var existingDisease = appDbContext.Diseases
                    .Include(d => d.DiseaseCodes)
                    .FirstOrDefault(x => x.DiseaseId == disease.DiseaseId);


                // Disease codes removal
                foreach (var diseaseCode in existingDisease.DiseaseCodes)
                {
                    if (!disease.DiseaseCodes.Any(c => c.DiseaseCodeId == diseaseCode.DiseaseCodeId))
                    {
                        var existingDiseaseCode = appDbContext.DiseaseCodes.FirstOrDefault(x => x.DiseaseCodeId == diseaseCode.DiseaseCodeId);
                        existingDisease.DiseaseCodes.Remove(existingDiseaseCode);
                    }
                }

                // Disease codes addition
                foreach (var diseaseCode in disease.DiseaseCodes)
                { 
                    if(!existingDisease.DiseaseCodes.Any(c => c.DiseaseCodeId == diseaseCode.DiseaseCodeId))
                    {
                        var existingDiseaseCode = appDbContext.DiseaseCodes.FirstOrDefault(x => x.DiseaseCodeId == diseaseCode.DiseaseCodeId);
                        existingDisease.DiseaseCodes.Add(existingDiseaseCode);
                    }
                }

                appDbContext.ChangeTracker.DetectChanges();
                var debugView = appDbContext.ChangeTracker?.DebugView.ShortView;

                appDbContext.SaveChanges();

            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Class} {Exception}", nameof(UpdateDiseaseAsync), nameof(DiseasesRepository), exception);
            }
            //}

            await appDbContext.SaveChangesAsync();

            return disease;
        }
    }
}
