using Microsoft.EntityFrameworkCore;
using Oncogenes.Domain;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;

namespace Oncogenes.DAL.Repository
{
    public class DiseasesRepository : IDiseasesRepository
    {
        private readonly OncogenesContext appDbContext;
        public DiseasesRepository(OncogenesContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Disease>> GetAllDiseases()
        {
            return await appDbContext.Diseases
                .Include(d => d.Oncogenes)
                .Include(d => d.DiseaseCodes)
                .Include(d => d.MedicalTests)
                .Include(d => d.Treatments)
                .ToListAsync();
        }

        public async Task<Disease?> GetDiseaseById(int id)
        {
            return await appDbContext.Diseases
                .Include(d => d.DiseaseCodes)
                .Include(d => d.MedicalTests)
                .Include(d => d.Treatments)
                .FirstOrDefaultAsync(d => d.Id == id);
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


        public async Task<Disease> UpdateDiseaseAsync(Disease disease)
        {
            var existingDisease = appDbContext.Diseases
                        .Include(b => b.DiseaseCodes).ThenInclude(d => d.Diseases)
                         .FirstOrDefault(b => b.Id == disease.Id);

            // add missing codes
            foreach(var dCode in disease.DiseaseCodes)
            {
                if(dCode != null && !existingDisease.DiseaseCodes.Any(x => x.DiseaseCodeId == dCode.DiseaseCodeId))
                {
                    var existingCode = appDbContext.DiseaseCodes.FirstOrDefault(p => p.DiseaseCodeId == dCode.DiseaseCodeId);
                    existingDisease.DiseaseCodes.Add(existingCode);
                    existingCode.Diseases.Add(existingDisease);                  
                }
            }

            appDbContext.SaveChanges();


            foreach (var dCode in existingDisease.DiseaseCodes)
            {
                if (dCode != null && !disease.DiseaseCodes.Any(x => x.DiseaseCodeId == dCode.DiseaseCodeId))
                {
                    var codeToRemove = appDbContext.DiseaseCodes.FirstOrDefault(p => p.DiseaseCodeId == dCode.DiseaseCodeId);

                    var existingDiseaseToRemove = appDbContext.Diseases.FirstOrDefault(b => b.Id == disease.Id);

                    if (codeToRemove != null)
                    {
                        //existingDisease.DiseaseCodes.Remove(codeToRemove);
                        codeToRemove.Diseases.Remove(existingDiseaseToRemove);
                    }
                }
            }

            appDbContext.SaveChanges();

           
            return existingDisease;
        }
    }
}
