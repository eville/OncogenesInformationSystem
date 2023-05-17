using Oncogenes.Domain;
namespace Oncogenes.DAL.Repository
{
    public interface IOncogenesRepository
    {
        IEnumerable<Gene> GetAllGenes();
        Gene GetGeneById(int geneId);
    }
}