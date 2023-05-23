using Oncogenes.Domain;

namespace Oncogenes.App.Services
{
    public interface IDiseaseCodeDataService
    {
        Task<DiseaseCode> AddDiseaseCode(DiseaseCode diseaseCode);
        Task DeleteDiseaseCode(int id);
        Task<DiseaseCode> GetDiseaseCodeById(int id);
        Task<IEnumerable<DiseaseCode>> GetDiseaseCodes();
        Task UpdateDiseaseCode(DiseaseCode diseaseCode);
    }
}