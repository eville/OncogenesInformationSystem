using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oncogenes.Domain
{
    public class Treatment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TreatmentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Note { get; set; }

        public List<Disease> Diseases { get; set; } = new();
    }
}
