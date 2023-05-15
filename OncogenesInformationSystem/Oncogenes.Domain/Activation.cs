using System.ComponentModel.DataAnnotations;

namespace Oncogenes.Domain
{
    public class Activation
    {
        [Key]
        public int ActivationId { get; set; }

        public int OncogeneId { get; set; }

        public int DiseaseId { get; set; }

        public string MutationRemark { get; set; }

        public string DrugCombination { get; set; }

        public string ActionabilityRank { get; set; }

        public string DevelopmentStatus { get; set; }

        public string TestingRequired { get; set; }

        public string TestingStatus { get; set; }

        public string TrialPrimaryCompletionDate { get; set; }

        public Oncogene Oncogene { get; set; }
        public Disease Disease { get; set; }
        public List<Drug> Drugs { get; set; } = new();
    }
}
