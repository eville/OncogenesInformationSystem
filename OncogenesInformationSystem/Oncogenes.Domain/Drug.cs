using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public class Drug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrugId { get; set; }
        public string GenericDrugName { get; set; }

        public List<Activation> Activations { get; set; } = new();

        public List<Gene> Oncogenes { get; set; } = new();

    }
}
