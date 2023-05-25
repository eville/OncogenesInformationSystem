using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Note { get; set; }

        public List<Disease> Diseases { get; set; } = new ();
    }
}
