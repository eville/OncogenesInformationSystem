using Microsoft.AspNetCore.Components;
using Oncogenes.App.Services;
using Oncogenes.Domain;

namespace Oncogenes.App.Pages
{
    public partial class DiseasesEditor
    {

        private bool ShowForm { get; set; } = false;

        [Parameter]
        public string DiseaseId { get; set; } = string.Empty;

        private Disease Disease = new Disease();
        public List<Disease>? Diseases { get; set; } = default;

        [Inject]
        public IDiseasesDataService? DiseasesDataService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Diseases = (await DiseasesDataService.GetDiseases()).ToList();
        }


        private async Task DeleteDiseaseAsync(int id)
        {
            await DiseasesDataService.DeleteDisease(id);
            Diseases = (await DiseasesDataService.GetDiseases()).ToList();
        }

        private async Task AddDiseaseAsync()
        {
            
            var disease =  await DiseasesDataService.AddDisease(Disease);
            if(disease != null)
            {
                Diseases = (await DiseasesDataService.GetDiseases()).ToList();
            }
            Disease = new Disease();

            ShowForm = false;
        }

        private void ToggleForm()
        {
            ShowForm = !ShowForm;
        }

    }
}
