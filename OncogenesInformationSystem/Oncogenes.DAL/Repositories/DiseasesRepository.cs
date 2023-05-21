using Microsoft.EntityFrameworkCore;
using Oncogenes.Domain;

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
                .Include(d => d.MedicalTests)
                .Include(d => d.Treatments)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
