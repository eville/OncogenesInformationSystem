using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public class MedicalTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicalTestId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Note { get; set; }

        public List<Disease> Diseases { get; set; } = new();

    }
}
