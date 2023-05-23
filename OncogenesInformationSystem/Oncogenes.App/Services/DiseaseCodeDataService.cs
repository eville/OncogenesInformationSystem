using Oncogenes.Domain;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace Oncogenes.App.Services
{
    public class DiseaseCodeDataService : IDiseaseCodeDataService
    {
        private readonly HttpClient httpClient;

        private readonly ILogger<DiseaseCodeDataService> logger;

        public DiseaseCodeDataService(ILogger<DiseaseCodeDataService> logger, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<IEnumerable<DiseaseCode>> GetDiseaseCodes()
        {
            try
            {
                IEnumerable<DiseaseCode>? allDiseaseCode = await JsonSerializer.DeserializeAsync<IEnumerable<DiseaseCode>>
                          (await this.httpClient.GetStreamAsync($"api/DiseaseCode"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, ReferenceHandler = ReferenceHandler.Preserve });
                return allDiseaseCode;
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(GetDiseaseCodes), $"api/DiseaseCode", exception);
                return Array.Empty<DiseaseCode>();
            }
        }

        public async Task<DiseaseCode> GetDiseaseCodeById(int id)
        {
            try
            {
                DiseaseCode? diseaseCode = await JsonSerializer.DeserializeAsync<DiseaseCode>
                          (await this.httpClient.GetStreamAsync($"api/DiseaseCode/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, ReferenceHandler = ReferenceHandler.Preserve });
                return diseaseCode;
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(GetDiseaseCodeById), $"api/DiseaseCode/{id}", exception);
                return new DiseaseCode();
            }
        }

        public async Task<DiseaseCode> AddDiseaseCode(DiseaseCode diseaseCode)
        {
            try
            {
                var diseaseCodeJson =
                 new StringContent(JsonSerializer.Serialize(diseaseCode), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("api/DiseaseCode", diseaseCodeJson);

                if (response.IsSuccessStatusCode)
                {
                    return await JsonSerializer.DeserializeAsync<DiseaseCode>(await response.Content.ReadAsStreamAsync());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(AddDiseaseCode), $"api/DiseaseCode", exception);
                return new DiseaseCode();
            }
        }

        public async Task UpdateDiseaseCode(DiseaseCode diseaseCode)
        {
            try
            {
                var diseaseCodeJson =
                 new StringContent(JsonSerializer.Serialize(diseaseCode, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, ReferenceHandler = ReferenceHandler.Preserve }), Encoding.UTF8, "application/json");

                //var response = await httpClient.PostAsync("api/DiseaseCode", diseaseCodeJson);




                var x = await httpClient.PutAsync($"api/DiseaseCode/{diseaseCode.DiseaseCodeId}", diseaseCodeJson);
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(UpdateDiseaseCode), $"api/DiseaseCode/{diseaseCode.DiseaseCodeId}", exception);
            }
        }

        public async Task DeleteDiseaseCode(int id)
        {
            try
            {
                await httpClient.DeleteAsync($"api/DiseaseCode/{id}");
            }
            catch (Exception exception)
            {
                logger.LogError("Exception occurred in {Method} {Path} {Exception}", nameof(DeleteDiseaseCode), $"api/DiseaseCode/{id}", exception);
            }
        }

    }
}
