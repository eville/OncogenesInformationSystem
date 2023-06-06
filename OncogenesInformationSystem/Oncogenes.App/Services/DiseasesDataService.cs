using Oncogenes.Domain;
using System.Text.Json;
using System.Text;

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
                          (await this.httpClient.GetStreamAsync($"api/Diseases"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return allDiseases;
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(GetDiseases), $"api/Diseases", exception);
                return Array.Empty<Disease>();
            }
        }

        public async Task<Disease> GetDiseaseById(int id)
        {
            try
            {
                Disease? disease = await JsonSerializer.DeserializeAsync<Disease>
                          (await this.httpClient.GetStreamAsync($"api/Diseases/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return disease;
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(GetDiseases), $"api/Diseases/{id}", exception);
                return new Disease();
            }
        }

        public async Task<Disease> AddDisease(Disease disease)
        {
            try
            {
                var diseaseInJson =
                 new StringContent(JsonSerializer.Serialize(disease), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("api/Diseases", diseaseInJson);

                if (response.IsSuccessStatusCode)
                {
                    return await JsonSerializer.DeserializeAsync<Disease>(await response.Content.ReadAsStreamAsync());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(AddDisease), $"api/Diseases", exception);
                return new Disease();
            }
        }

        public async Task UpdateDisease(Disease disease)
        {
            try
            {

                var diseaseInJson =
                new StringContent(JsonSerializer.Serialize(disease), Encoding.UTF8, "application/json");

                await httpClient.PutAsync($"api/Diseases", diseaseInJson);
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(UpdateDisease), $"api/Diseases/{disease.DiseaseId}", exception);
            }
        }

        public async Task DeleteDisease(int id)
        {
            try
            {
                await httpClient.DeleteAsync($"api/Diseases/{id}");
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(DeleteDisease), $"api/Diseases/{id}", exception);
            }
        }

    }
}
