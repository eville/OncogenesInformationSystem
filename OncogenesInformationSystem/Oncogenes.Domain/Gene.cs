using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public class Gene
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Symbol { get; set; }

        [Required]
        public string Name { get; set; }

        public string? CancerSyndrome { get; set; }

        public string? TumorTypes { get; set; }

        public List<Disease> Diseases { get; set; } = new();

        public List<Drug> Drugs { get; set; } = new();

        public List<Activation> Activations { get; set; } = new();

    }
}