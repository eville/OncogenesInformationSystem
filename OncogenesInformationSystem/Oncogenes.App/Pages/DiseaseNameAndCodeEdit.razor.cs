using Microsoft.AspNetCore.Components;
using Oncogenes.App.Services;
using Oncogenes.Domain;
using System.ComponentModel;

namespace Oncogenes.App.Pages
{
    public partial class DiseaseNameAndCodeEdit
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

        private bool ShowForm { get; set; } = false;

        private List<DiseaseCode> filteredCodes { get; set; }

        private string[] options;

        private string SelectedOption { get; set; } = string.Empty;
        

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

                    GetCodesForDropDown();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Logger.LogError($"Exception occured while manipulating disease codes in {nameof(DiseaseNameAndCodeEdit)}", ex.Message);
            }
            
        }

        public async Task DeleteDiseaseCodeAsync(int diseaseId, int diseaseCodeId)
        {
            var disease = await DiseasesDataService?.GetDiseaseById(diseaseId);
           
            var diseaseCodeToRemove = disease.DiseaseCodes.FirstOrDefault(c => c.DiseaseCodeId == diseaseCodeId);

            if (diseaseCodeToRemove != null)
            {
                disease.DiseaseCodes.Remove(diseaseCodeToRemove);
            }
            
           await DiseasesDataService?.UpdateDisease(disease);

            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }

        public static string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        private void ToggleForm()
        {
            ShowForm = !ShowForm;
        }

        private class FormData
        {
            public string SelectedOption { get; set; }
        }

        private async Task HandleValidSubmit()
        {
           if(!string.IsNullOrEmpty(SelectedOption))
            {
                foreach(var code in filteredCodes)
                {
                    if (SelectedOption.Contains(code.DiseaseClassificator))
                    {
                        Disease.DiseaseCodes.Add(code);
                        await DiseasesDataService?.UpdateDisease(Disease);
                        SelectedOption = string.Empty;
                        filteredCodes.Remove(code);
                        break;
                    }
                }                
            }

            GetCodesForDropDown();
        }

        private async Task GetCodesForDropDown()
        {
            IEnumerable<DiseaseCode> diseaseCodes = await DiseaseCodesDataService?.GetDiseaseCodes();

            filteredCodes = diseaseCodes?.Where(dc1 => !Disease.DiseaseCodes.Any(alreadyIn => alreadyIn.DiseaseCodeId == dc1.DiseaseCodeId)).ToList();

            options = filteredCodes?.Select(d => $"{d.DiseaseClassificator} {d.CodeDescription}").ToArray();
        }
    }
}
