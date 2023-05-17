using Oncogenes.Domain;

namespace Oncogenes.DAL.Repository
{
    public class OncogenesRepository : IOncogenesRepository
    {
        private readonly OncogenesContext _appDbContext;

        public OncogenesRepository(OncogenesContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Gene> GetAllGenes()
        {
            return _appDbContext.Oncogenes.ToList();
        }

        public Gene GetGeneById(int geneId)
        {
            return _appDbContext.Oncogenes.FirstOrDefault(c => c.Id == geneId);
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
