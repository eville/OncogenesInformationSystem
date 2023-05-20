using Oncogenes.Domain;

namespace Oncogenes.App.Pages
{
    public partial class DiseaseOverView
    {
        public List<Disease> Diseases { get; set; } = new List<Disease>()
        {
            new Disease()
            {
                Name = "Breast Cancer",

            },

            new Disease()
            {
                Name = "Lung Cancer",
            },


            new Disease()
            {
                Name = "Prostate Cancer",
            },
        };
    }
}
