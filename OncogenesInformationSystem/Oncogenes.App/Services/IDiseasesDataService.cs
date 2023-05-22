using Oncogenes.Domain;

namespace Oncogenes.App.Services
{
    public interface IDiseasesDataService
    {
        Task<IEnumerable<Disease>> GetDiseases();

        Task<Disease> GetDiseaseById(int id);

        Task<Disease> AddDisease(Disease disease);

        Task DeleteDisease(int id);

        Task UpdateDisease(Disease disease);
    }
}