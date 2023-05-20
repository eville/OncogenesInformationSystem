using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oncogenes.Domain;
using System.Linq;

namespace Oncogenes.DAL.Repository
{
    public class OncogenesRepository : IOncogenesRepository
    {
        private readonly OncogenesContext appDbContext;

        public OncogenesRepository(OncogenesContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Gene>> GetAllGenes()
        {
            return await appDbContext.Oncogenes
                .Include(c => c.Diseases).ThenInclude(c => c.Treatments)
                .Include(c => c.Drugs)
                .Include(c => c.Activations).ThenInclude(c => c.Drugs)
                .ToListAsync();

        }

        public async Task<Gene> GetGeneById(int geneId)
        {
            return await appDbContext.Oncogenes.FirstOrDefaultAsync(c => c.Id == geneId);
        }

        public void AddGene(Gene gene)
        {
            appDbContext.Oncogenes.Add(gene);

            appDbContext.SaveChanges();
        }

        public void DeleteGene(int geneId)
        {
            var gene = appDbContext.Oncogenes.FirstOrDefault(c => c.Id == geneId);

            if (gene != null)
            {
                appDbContext.Oncogenes.Remove(gene);
                appDbContext.SaveChanges();
            }

        }
    }
}
