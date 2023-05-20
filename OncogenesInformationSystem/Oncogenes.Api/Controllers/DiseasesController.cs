using Microsoft.AspNetCore.Mvc;
using Oncogenes.DAL.Repository;
using Oncogenes.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oncogenes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseasesRepository diseasesRepository;
        public DiseasesController(ILogger<DiseasesController> logger, IDiseasesRepository diseasesRepository)
        {
            this.diseasesRepository = diseasesRepository;
        }
        // GET: api/<DiseaseController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetDiseases()
        {
            var diseases = await diseasesRepository.GetAllDiseases();
            return Ok(diseases);
        }

        // GET api/<DiseaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DiseaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DiseaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DiseaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
