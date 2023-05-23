using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public class MedicalTest
    {
        [Key]
        public int MedicalTestId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Note { get; set; }

        [JsonIgnore]
        public List<Disease> Diseases { get; set; } = new();

    }
}
