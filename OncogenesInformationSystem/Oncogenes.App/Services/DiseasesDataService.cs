using Microsoft.Extensions.Logging;
using Oncogenes.Domain;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Oncogenes.App.Services
{
    public class DiseasesDataService : IDiseasesDataService
    {
        private readonly HttpClient httpClient;

        private readonly ILogger<DiseasesDataService> logger;

        public DiseasesDataService(ILogger<DiseasesDataService> logger, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<IEnumerable<Disease>> GetDiseases()
        {
            try
            {
                IEnumerable<Disease>? allDiseases = await JsonSerializer.DeserializeAsync<IEnumerable<Disease>>
                          (await this.httpClient.GetStreamAsync($"api/Diseases"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, ReferenceHandler = ReferenceHandler.Preserve });
                return allDiseases;
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(GetDiseases), $"api/Oncogenes", exception);
                return Array.Empty<Disease>();
            }
        }

    }
}
