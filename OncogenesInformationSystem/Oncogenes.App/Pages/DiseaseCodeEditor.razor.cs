using Microsoft.AspNetCore.Components;
using Oncogenes.App.Services;
using Oncogenes.Domain;
using System.ComponentModel;
using System.Reflection;

namespace Oncogenes.App.Pages
{
    public partial class DiseaseCodeEditor
    {
        public List<DiseaseCode>? DiseaseCodes { get; set; } = default;

        public DiseaseCode DiseaseCode { get; set; } 
        public List<string> DiseaseCodeTypesValues { get; set; }

        private bool ShowForm { get; set; } = false;

        [Inject]
        public IDiseaseCodeDataService? DiseaseCodeDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            DiseaseCode = new DiseaseCode();
            DiseaseCodes = (await DiseaseCodeDataService.GetDiseaseCodes()).ToList();
        }


        public async Task HandleValidSubmitAsync(DiseaseCode diseaseCode)
        {
            await DiseaseCodeDataService.UpdateDiseaseCode(diseaseCode);
            //DiseaseCodes = (await DiseaseCodeDataService.GetDiseaseCodes()).ToList();
        }

        public async Task DeleteDiseaseCodeAsync(int id)
        {
            await DiseaseCodeDataService.DeleteDiseaseCode(id);
            DiseaseCodes = (await DiseaseCodeDataService.GetDiseaseCodes()).ToList();
        }


        public string GetDescription<TEnum>(TEnum enumValue)
        where TEnum : struct, IConvertible // Ensure it is an enum
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Argument must be an enum");
            }
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DescriptionAttribute>()
                            ?.Description
                   ?? enumValue.ToString(); // Return the name as a fallback
        }

        private async Task AddDiseaseCodeAsync()
        {

            var diseaseCode = await DiseaseCodeDataService.AddDiseaseCode(DiseaseCode);
            if (diseaseCode != null)
            {
                DiseaseCodes = (await DiseaseCodeDataService.GetDiseaseCodes()).ToList();
            }
            DiseaseCode = new DiseaseCode();

            ShowForm = false;
        }

        private void ToggleForm()
        {
            ShowForm = !ShowForm;
        }

        //private void UpdateVisibility(ChangeEventArgs e)
        //{
        //    if (Enum.TryParse(typeof(DiseaseCodeTypes), e.Value.ToString(), out var selectedValue))
        //    {
        //        ShowLevel = (DiseaseCodeTypes)selectedValue != DiseaseCodeTypes.ORPHA;
        //    }
        //}
    }
}
