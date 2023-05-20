using Oncogenes.Domain;

namespace Oncogenes.DAL.Repository
{
    public interface IDiseasesRepository
    {
        Task<IEnumerable<Disease>> GetAllDiseases();
    }
}