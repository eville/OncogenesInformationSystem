using Microsoft.AspNetCore.Components;
using Oncogenes.App.Services;
using Oncogenes.Domain;

namespace Oncogenes.App.Pages
{
    public partial class DiseasesOverview
    {
        public List<Disease>? Diseases { get; set; } = default;

        [Inject]
        public IDiseasesDataService? DiseasesDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Diseases = (await DiseasesDataService.GetDiseases()).ToList();
        }
    }
}
