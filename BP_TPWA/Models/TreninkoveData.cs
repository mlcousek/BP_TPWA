using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BP_TPWA.Models
{
    public class TreninkoveData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UzivatelId { get; set; }
        public double VahaUzivatele { get; set; }
        public DateTime Datum { get; set; }
        public int CvikId { get; set; }
        public int CisloSerie { get; set; }
        public int PocetOpakovani { get; set; }
        public int CvicenaVaha { get; set; }

        //// Kaskádové mazání pro vztah s tabulkou Uzivatel
        //[ForeignKey("UzivatelId")]
        //public virtual Uzivatel Uzivatel { get; set; }

       // Kaskádové mazání pro vztah s tabulkou Cvik
       [ForeignKey("CvikId")]
        public virtual Cvik Cvik { get; set; }
    }
}
