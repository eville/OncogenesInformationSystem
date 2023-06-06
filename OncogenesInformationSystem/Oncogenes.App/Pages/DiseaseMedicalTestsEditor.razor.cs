using Microsoft.AspNetCore.Components;
using Oncogenes.App.Services;
using Oncogenes.Domain;

namespace Oncogenes.App.Pages
{
    public partial class DiseaseMedicalTestsEditor
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILogger<DiseaseNameAndCodeEdit>? Logger { get; set; }
        [Inject]
        public IDiseasesDataService? DiseasesDataService { get; set; }

        [Inject]
        public IDiseaseCodeDataService? DiseaseCodesDataService { get; set; }

        [Parameter]
        public string? DiseaseId { get; set; }

        public Disease Disease { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (int.TryParse(DiseaseId, out int id))
                {
                    Disease = await DiseasesDataService?.GetDiseaseById(id);
                }
                else
                {
                    Disease = new Disease();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Logger.LogError($"Exception occured while manipulating disease codes in {nameof(DiseaseNameAndCodeEdit)}", ex.Message);
            }

        }

        public async Task HandleValidSubmitAsync(MedicalTest medicalTest)
        {
            await DiseasesDataService.UpdateDisease(Disease);
            ////DiseaseCodes = (await DiseaseCodeDataService.GetDiseaseCodes()).ToList();
        }

        public async Task DeleteMedicalTest(int id)
        {
            //await DiseaseCodeDataService.DeleteMedicalTest(id);
            //DiseaseCodes = (await DiseaseCodeDataService.GetDiseaseCodes()).ToList();
        }
    }
}
