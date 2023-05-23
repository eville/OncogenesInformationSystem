using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public class Drug
    {
        [Key]
        public int DrugId { get; set; }
        public string GenericDrugName { get; set; }

        [JsonIgnore]
        public List<Activation> Activations { get; set; } = new();
        
        [JsonIgnore]
        public List<Gene> Oncogenes { get; set; } = new();

    }
}
