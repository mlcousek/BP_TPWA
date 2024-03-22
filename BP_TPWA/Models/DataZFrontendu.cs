using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BP_TPWA.Models
{
    public class DataZFrontendu
    {
        public string Datum { get; set; }
        public int CvikId { get; set; }
        public int CisloSerie { get; set; }
        public int PocetOpakovani { get; set; }
        public int CvicenaVaha { get; set; }

    }
}
