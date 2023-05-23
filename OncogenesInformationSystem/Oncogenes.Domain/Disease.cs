using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Gene> Oncogenes { get; set; } = new();

        [JsonIgnore]
        public List<Activation> Activations { get; set; } = new();

        [JsonIgnore]
        public List<MedicalTest> MedicalTests { get; set; } = new();

        public List<DiseaseCode> DiseaseCodes { get; set; } = new();

        [JsonIgnore]
        public List<Treatment> Treatments { get; set; } = new();
    }
}
