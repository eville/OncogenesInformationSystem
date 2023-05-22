using Oncogenes.Domain;

namespace Oncogenes.DAL.Repositories
{
    public interface IDiseaseCodesRepository
    {
        Task<DiseaseCode> AddDiseaseCodeAsync(DiseaseCode code);
        Task DeleteDiseaseCodeAsync(DiseaseCode code);
        Task<IEnumerable<DiseaseCode>> GetAllCodes();
        Task<DiseaseCode?> GetDiseaseCodeById(int id);
        Task<DiseaseCode> UpdateDiseaseCodeAsync(DiseaseCode code);
    }
}