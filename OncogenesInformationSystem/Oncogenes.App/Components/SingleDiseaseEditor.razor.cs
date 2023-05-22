using Microsoft.AspNetCore.Components;
using Oncogenes.Domain;

namespace Oncogenes.App.Components
{
    public partial class SingleDiseaseEditor
    {
        [Parameter]
        public Disease Disease { get; set; } = default!;

        //[Parameter]
        //public Disease Disease { get; set; } = new Disease();
        //[Parameter]
        //public EventCallback<Disease> OnEditDisease { get; set; }
        //[Parameter]
        //public EventCallback<int> OnDeleteDisease { get; set; }
        //[Parameter]
        //public EventCallback OnAddDisease { get; set; }
        //[Parameter]
        //public bool ShowForm { get; set; } = false;
        //private void ToggleForm()
        //{
        //    ShowForm = !ShowForm;
        //}
        //private async Task EditDiseaseAsync()
        //{
        //    await OnEditDisease.InvokeAsync(Disease);
        //}
        //private async Task DeleteDiseaseAsync()
        //{
        //    await OnDeleteDisease.InvokeAsync(Disease.Id);
        //}
        //private async Task AddDiseaseAsync()
        //{
        //    await OnAddDisease.InvokeAsync();
        //}   
    }
}
