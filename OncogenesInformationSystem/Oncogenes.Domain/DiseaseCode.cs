using System.ComponentModel.DataAnnotations;

namespace Oncogenes.Domain
{
    public  class DiseaseCode
    {
        [Key]
        public int DiseaseCodeId { get; set; }
        
        public int DiseaseId { get; set; }

        public string Code { get; set; }

        public string CodeDescription { get; set; }
        
        public int CodeLevel { get; set; }

        public string? OrphaCode { get; set; }

        public Disease Disease { get; set; }

    }
}
