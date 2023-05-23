using System.ComponentModel.DataAnnotations;

namespace Oncogenes.Domain
{
    public  class DiseaseCode
    {
        [Key]
        public int DiseaseCodeId { get; set; }
        
        public int DiseaseId { get; set; }

        public string Code { get; set; }

        public int CodeType { get; set; } = 0;

        public string? CodeDescription { get; set; }
        
        public int? CodeLevel { get; set; }

        public Disease Disease { get; set; }

    }
}
