using Oncogenes.Domain;

namespace Oncogenes.App.Services
{
    public interface IDiseasesDataService
    {
        Task<IEnumerable<Disease>> GetDiseases();
    }
}