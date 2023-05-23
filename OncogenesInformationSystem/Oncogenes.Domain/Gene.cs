using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public class Gene
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Symbol { get; set; }

        [Required]
        public string Name { get; set; }

        public string? CancerSyndrome { get; set; }

        public string? TumorTypes { get; set; }

        [JsonIgnore]
        public List<Disease> Diseases { get; set; } = new();

        [JsonIgnore]
        public List<Drug> Drugs { get; set; } = new();
        
        [JsonIgnore]
        public List<Activation> Activations { get; set; } = new();

    }
}