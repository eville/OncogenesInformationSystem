using Microsoft.AspNetCore.Mvc;
using Oncogenes.DAL.Repositories;
using Oncogenes.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oncogenes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseCodeController : ControllerBase
    {
        private readonly IDiseaseCodesRepository diseaseCodeRepository;
        public DiseaseCodeController(ILogger<DiseaseCodeController> logger, IDiseaseCodesRepository diseaseCodeRepository)
        {
            this.diseaseCodeRepository = diseaseCodeRepository;
        }

        // GET: api/<DiseaseCodeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseCode>>> GetDiseaseCodes()
        {
            var diseases = await diseaseCodeRepository.GetAllCodes();
            return Ok(diseases);
        }

        // GET api/<DiseaseCodeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseCode>> GetDiseaseById(int id)

        {
            var diseaseCode = await diseaseCodeRepository.GetDiseaseCodeById(id);

            if (diseaseCode == null)
            {
                return NotFound();
            }

            return Ok(diseaseCode);
        }

        // POST api/<DiseaseCodeController>
        [HttpPost]
        public async Task<ActionResult<DiseaseCode>> AddDiseaseCode(DiseaseCode disease)
        {
            if (ModelState.IsValid)
            {
                var addedDiseaseCode = await diseaseCodeRepository.AddDiseaseCodeAsync(disease);
                return CreatedAtAction(nameof(AddDiseaseCode), new { id = addedDiseaseCode.DiseaseCodeId }, addedDiseaseCode);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<DiseaseCodeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DiseaseCode>> Put(int id, DiseaseCode diseaseCode)
        {
            var existingDiseaseCode = await diseaseCodeRepository.GetDiseaseCodeById(diseaseCode.DiseaseCodeId);
            if (existingDiseaseCode == null)
            {
                return NotFound();
            }

            existingDiseaseCode.Code = diseaseCode.Code;
            existingDiseaseCode.CodeDescription = diseaseCode.CodeDescription;
            existingDiseaseCode.CodeType = diseaseCode.CodeType;


            var updatedDisease = await diseaseCodeRepository.UpdateDiseaseCodeAsync(existingDiseaseCode);
            return Ok(updatedDisease);
        }

        // DELETE api/<DiseaseCodeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DiseaseCode>> DeleteDiseaseCode(int id)
        {
            var diseaseCode = await diseaseCodeRepository.GetDiseaseCodeById(id);
            if (diseaseCode == null)
            {
                return NotFound();
            }

            await diseaseCodeRepository.DeleteDiseaseCodeAsync(diseaseCode);

            return NoContent();
        }
    }
}
