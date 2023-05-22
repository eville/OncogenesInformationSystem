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
            return await appDbContext.DiseaseCodes.ToListAsync();
        }

        public async Task<DiseaseCode?> GetDiseaseCodeById(int id)
        {
            return await appDbContext.DiseaseCodes.FirstOrDefaultAsync(c => c.DiseaseCodeId == id);

        }

        public async Task<DiseaseCode> AddDiseaseCodeAsync(DiseaseCode code)
        {
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;

            var existingCode = appDbContext.DiseaseCodes
            .AsEnumerable().FirstOrDefault(d => compareInfo.Compare(d.Code, code.Code, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0);

            if (existingCode != null)
            {
                throw new Exception("Tokiu numeriu kodas jau yra sistemoje.");
            }
            else
            {
                await appDbContext.DiseaseCodes.AddAsync(code);
                await appDbContext.SaveChangesAsync();
                return code;
            }

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
