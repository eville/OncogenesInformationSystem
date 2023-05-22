using Oncogenes.Domain;

namespace Oncogenes.DAL.Repository
{
    public interface IDiseasesRepository
    {
        Task<IEnumerable<Disease>> GetAllDiseases();

        Task<Disease?> GetDiseaseById(int id);

        Task<Disease> AddDiseaseAsync(Disease disease);

        Task DeleteAsync(Disease disease);

        Task<Disease> UpdateDiseaseAsync(Disease disease);
    }
}