using Microsoft.AspNetCore.Components;
using Oncogenes.App.Services;
using Oncogenes.Domain;
using Oncogenes.Domain.Enums;
using System.ComponentModel;
using System.Reflection;

namespace Oncogenes.App.Pages
{
    public partial class DiseaseCodeEditor
    {
        public List<DiseaseCode>? DiseaseCodes { get; set; } = default;

        public List<string> DiseaseCodeTypes { get; set; }

        [Inject]
        public IDiseaseCodeDataService? DiseaseCodeDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {

            DiseaseCodes = (await DiseaseCodeDataService.GetDiseaseCodes()).ToList();
        }


        private void HandleValidSubmit()
        {
            // Here you handle the form submission.
            // For example, you might want to save the model to a database or call an API.
            Console.WriteLine($"Submitted: {diseaseCode.CodeLevel}");
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
    }
}
