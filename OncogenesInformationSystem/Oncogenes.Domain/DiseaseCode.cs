using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public  class DiseaseCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiseaseCodeId { get; set; }

        [Required]
        public string DiseaseClassificator { get; set; }

        [Required]
        public int CodeType { get; set; } = 0;

        public string? CodeDescription { get; set; }

        public List<Disease> Diseases { get; set; } = new();
    }
}
