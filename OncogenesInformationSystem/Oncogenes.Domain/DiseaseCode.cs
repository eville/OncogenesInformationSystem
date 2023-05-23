using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Oncogenes.Domain
{
    public  class DiseaseCode
    {
        [Key]
        public int DiseaseCodeId { get; set; }
        
        public string Code { get; set; }

        public int CodeType { get; set; } = 0;

        public string? CodeDescription { get; set; }

        public List<Disease> Diseases { get; set; } = new();
    }
}
