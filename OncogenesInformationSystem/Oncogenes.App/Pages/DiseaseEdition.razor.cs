using Microsoft.AspNetCore.Components;
using Oncogenes.App.Services;
using Oncogenes.Domain;

namespace Oncogenes.App.Pages
{
    public partial class DiseaseEdition
    {
        [Inject]
        public IDiseasesDataService? DiseasesDataService { get; set; }

        [Parameter]
        public string? DiseaseId { get; set; }


        public Disease Disease { get; set; }

        protected override async Task OnInitializedAsync()
        {

            if(int.TryParse(DiseaseId, out int id))
            {
                Disease = await DiseasesDataService?.GetDiseaseById(id);
            }
            else
            {
                Disease = new Disease();
            }

        }
    }
}
