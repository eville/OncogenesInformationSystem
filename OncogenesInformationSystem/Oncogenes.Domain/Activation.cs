namespace Oncogenes.Domain
{
    public class Activation
    {
        public int ActivationId { get; set; }

        public int GeneId { get; set; }

        public int DiseaseId { get; set; }

        public string MutationRemark { get; set; }

        public string DrugCombination { get; set; }

        public string ActionabilityRank { get; set; }

        public string DevelopmentStatus { get; set; }

        public string TestingRequired { get; set; }

        public string TestingStatus { get; set; }

        public string TrialPrimaryCompletionDate { get; set; }
    }
}
