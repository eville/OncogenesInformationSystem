using Microsoft.Extensions.Logging;
using Oncogenes.Domain;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Oncogenes.App.Services
{
    public class OncogenesDataService : IOncogenesDataService
    {
        private readonly HttpClient httpClient;

        private readonly ILogger<OncogenesDataService> logger;
        public OncogenesDataService(ILogger<OncogenesDataService> logger, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public Task<Gene> AddGene(Gene gene)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGene(int gene)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Gene>> GetGenes()
        {
            try
            {
                IEnumerable<Gene>? allGenes = await JsonSerializer.DeserializeAsync<IEnumerable<Gene>>
                          (await this.httpClient.GetStreamAsync($"api/Oncogenes"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true,  ReferenceHandler = ReferenceHandler.Preserve});
                return allGenes;
            }
            catch(Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(GetGenes), $"api/Oncogenes", exception);
                return Array.Empty<Gene>();
            }
        }

        public Task<Gene> UpdateGene(Gene gene)
        {
            throw new NotImplementedException();
        }
    }
}
