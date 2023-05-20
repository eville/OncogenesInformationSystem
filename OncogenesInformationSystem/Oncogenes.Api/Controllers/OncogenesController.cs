using Microsoft.AspNetCore.Mvc;
using Oncogenes.DAL.Repository;
using Oncogenes.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oncogenes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OncogenesController : ControllerBase
    {
        private readonly IOncogenesRepository oncogenesRepository;

        public OncogenesController(ILogger<OncogenesController> logger, IOncogenesRepository oncogenesRepository)
        {
            this.oncogenesRepository = oncogenesRepository;
        }
        // GET: api/<OncogenesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gene>>> GetGenes()
        {
            var genes = await oncogenesRepository.GetAllGenes();
            return Ok(genes);
        }

        // GET api/<OncogenesController>/5
        // GET: api/Genes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gene>> GetGene(int id)
        {
            var gene = await oncogenesRepository.GetGeneById(id);

            if (gene == null)
            {
                return NotFound();
            }

            return Ok(gene);
        }

        // POST api/<OncogenesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OncogenesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OncogenesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
