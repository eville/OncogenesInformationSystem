using System.ComponentModel.DataAnnotations;

namespace Oncogenes.Domain
{
    public class Drug
    {
        [Key]
        public int DrugId { get; set; }
        public string GenericDrugName { get; set; }

        public List<Activation> Activations { get; set; } = new();

        public List<Gene> Oncogenes { get; set; } = new();

    }
}
