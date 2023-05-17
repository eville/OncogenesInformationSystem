using System.ComponentModel.DataAnnotations;

namespace Oncogenes.Domain
{
    public class MedicalTest
    {
        [Key]
        public int MedicalTestId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Note { get; set; }

        public List<Disease> Diseases { get; set; } = new();

    }
}
