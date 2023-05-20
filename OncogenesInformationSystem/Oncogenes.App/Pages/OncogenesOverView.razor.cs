using Microsoft.AspNetCore.Components;
using Oncogenes.App.Services;
using Oncogenes.Domain;
using System.Linq;

namespace Oncogenes.App.Pages
{
    public partial class OncogenesOverView
    {
        public List<Gene>? Oncogenes { get; set; } = default;

        [Inject]
        public IOncogenesDataService? OncogenesDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Oncogenes = (await OncogenesDataService.GetGenes()).ToList();
        }
    }
}
