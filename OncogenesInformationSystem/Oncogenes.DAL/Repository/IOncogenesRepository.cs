using Oncogenes.Domain;
namespace Oncogenes.DAL.Repository
{
    public interface IOncogenesRepository
    {
        IEnumerable<Oncogene> GetAllGenes();
        Oncogene GetGeneById(int geneId);
    }
}