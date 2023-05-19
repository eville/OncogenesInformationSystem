using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oncogenes.Domain;
using System.Linq;

namespace Oncogenes.DAL.Repository
{
    public class OncogenesRepository : IOncogenesRepository
    {
        private readonly OncogenesContext _appDbContext;

        public OncogenesRepository(OncogenesContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Gene>> GetAllGenes()
        {

            //var r1 = _appDbContext.Oncogenes.ToList();


            //var r2 = _appDbContext.Oncogenes
            //    .Include(c => c.Diseases)
            //    .ToList();

            //var r3 = _appDbContext.Oncogenes
            //    .Include(c => c.Drugs)
            //    .ToList();

            return await _appDbContext.Oncogenes
                .Include(c => c.Diseases).ThenInclude(c => c.Treatments)
                .Include(c => c.Drugs)
                .Include(c => c.Activations).ThenInclude(c => c.Drugs)
                .ToListAsync();

        }

        public async Task<Gene> GetGeneById(int geneId)
        {
            return await _appDbContext.Oncogenes.FirstOrDefaultAsync(c => c.Id == geneId);
        }

        public void AddGene(Gene gene)
        {
            _appDbContext.Oncogenes.Add(gene);

            _appDbContext.SaveChanges();
        }

        public void DeleteGene(int geneId)
        {
            var gene = _appDbContext.Oncogenes.FirstOrDefault(c => c.Id == geneId);

            if (gene != null)
            {
                _appDbContext.Oncogenes.Remove(gene);
                _appDbContext.SaveChanges();
            }

        }
    }
}
