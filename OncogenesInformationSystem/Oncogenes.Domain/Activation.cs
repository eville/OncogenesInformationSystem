using System.ComponentModel.DataAnnotations;

namespace Oncogenes.Domain
{
    public class Activation
    {
        [Key]
        public int ActivationId { get; set; }

        public int OncogeneId { get; set; }

        public string MutationRemark { get; set; }

        public string ActionabilityRank { get; set; }

        public int DevelopmentStatus { get; set; }

        public string TestingRequired { get; set; }

        public DateTime? TrialPrimaryCompletionDate { get; set; }

        public int? TrialStatus { get; set; }

        public int? CompletionStatus { get; set; }
        
        public string? Info { get; set; }

        public int? NumberOfPatients { get; set; }

        public int? TreatedNumber { get; set; }

        public int? ControlNumber { get; set; }

        public string? ControlTreatment { get; set; }

        public DateTime? LastUpdated { get; set; }

        public Gene Oncogene { get; set; }
        public List<Drug> Drugs { get; set; } = new();
    }
}
