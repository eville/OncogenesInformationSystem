using System.ComponentModel.DataAnnotations;

namespace Oncogenes.Domain
{
    public class Drug
    {
        [Key]
        public int DrugId { get; set; }
        public string ATC { get; set; }
        public string GenericName { get; set; }

        public List<Activation> Activations { get; set; } = new();

        public List<Oncogene> Oncogenes { get; set; } = new();

    }
}
