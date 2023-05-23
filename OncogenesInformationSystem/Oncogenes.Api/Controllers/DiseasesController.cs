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
        public async Task<ActionResult<Disease>> GetDiseaseById(int id)
        {
            var disease = await diseasesRepository.GetDiseaseById(id);

            if (disease == null)
            {
                return NotFound();
            }

            return Ok(disease);
        }

        // POST api/<DiseaseController>
        [HttpPost]
        public async Task<ActionResult<Disease>> AddDisease(Disease disease)
        {
            if (ModelState.IsValid)
            {
                var addedDisease = await diseasesRepository.AddDiseaseAsync(disease);
                return CreatedAtAction(nameof(AddDisease), new { id = addedDisease.Id }, addedDisease);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<DiseaseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Disease>> Put(int id, Disease disease)
        {
            if (id != disease.Id)
            {
                return BadRequest("Invalid disease ID");
            }

            var existingDisease = await diseasesRepository.GetDiseaseById(id);
            if (existingDisease == null)
            {
                return NotFound();
            }

            existingDisease.Name = disease.Name;


            var updatedDisease = await diseasesRepository.UpdateDiseaseAsync(existingDisease);
            return Ok(updatedDisease);
        }

        // DELETE api/<DiseaseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Disease>> DeleteDisease(int id)
        {
            var disease = await diseasesRepository.GetDiseaseById(id);
            if (disease == null)
            {
                return NotFound();
            }

            await diseasesRepository.DeleteAsync(disease);

            return NoContent();
        }
    }
}
