using System.ComponentModel.DataAnnotations;

namespace Oncogenes.Domain
{
    public class MedicalTest
    {
        [Key]
        public int MedicalTestId { get; set; }

        public string Name { get; set; }

        public List<Disease> Diseases { get; set; } = new();

    }
}
