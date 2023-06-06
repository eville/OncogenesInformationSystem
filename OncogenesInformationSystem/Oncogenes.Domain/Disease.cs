using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oncogenes.Domain
{
    public class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiseaseId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<DiseaseCode> DiseaseCodes { get; set; } = new();


        public List<Gene> Oncogenes { get; set; } = new();

        public List<Activation> Activations { get; set; } = new();

        public List<MedicalTest> MedicalTests { get; set; } = new();

        public List<Treatment> Treatments { get; set; } = new();
    }
}
