using Microsoft.EntityFrameworkCore;
using Oncogenes.Domain;
using System;
using System.Globalization;
using System.Linq;

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

            appDbContext.Diseases.Update(disease);
            await appDbContext.SaveChangesAsync();
            return disease;
        }
    }
}
