using System.Xml.Linq;

namespace Oncogenes.Domain
{
    public class Gene
    {
        public int GeneId { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string CancerSyndrome { get; set; }

        public string TumorTypes { get; set; }
    }
}