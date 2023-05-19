using Oncogenes.Domain;
namespace Oncogenes.DAL.Repository
{
    public interface IOncogenesRepository
    {
        Task<IEnumerable<Gene>> GetAllGenes();
        Task<Gene> GetGeneById(int id);
    }
}