using Microsoft.EntityFrameworkCore;
using Oncogenes.Domain;
using System.Globalization;

namespace Oncogenes.DAL.Repositories
{
    public class DiseaseCodesRepository : IDiseaseCodesRepository
    {
        private readonly OncogenesContext appDbContext;

        public DiseaseCodesRepository(OncogenesContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<DiseaseCode>> GetAllCodes()
        {
            return await appDbContext.DiseaseCodes.Include(c=>c.Diseases).ToListAsync();
        }

        public async Task<DiseaseCode?> GetDiseaseCodeById(int id)
        {
            return await appDbContext.DiseaseCodes.FirstOrDefaultAsync(c => c.DiseaseCodeId == id);

        }

        public async Task<DiseaseCode> AddDiseaseCodeAsync(DiseaseCode code)
        {
            await appDbContext.DiseaseCodes.AddAsync(code);
            await appDbContext.SaveChangesAsync();
            return code;

        }

        public async Task DeleteDiseaseCodeAsync(DiseaseCode code)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            appDbContext.DiseaseCodes.Remove(code);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<DiseaseCode> UpdateDiseaseCodeAsync(DiseaseCode code)
        {
            appDbContext.Entry(code).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return code;
        }
    }
}
