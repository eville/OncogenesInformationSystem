using Oncogenes.Domain;

namespace Oncogenes.App.Services
{
    public interface IOncogenesDataService
    {
        Task<IEnumerable<Gene>> GetGenes();

        Task<Gene> AddGene(Gene gene);

        Task<Gene> UpdateGene(Gene gene);

        Task DeleteGene(int gene);

    }
}