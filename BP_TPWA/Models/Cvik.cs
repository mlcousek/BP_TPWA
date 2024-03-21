using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BP_TPWA.Models
{
    public class Cvik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CvikId { get; set; }
        public string Název { get; set; }
        public string PočetOpakování { get; set; }
        public int PočetSérií { get; set; }
        public int PauzaMeziSériemi { get; set; }
        public string Partie {  get; set; }

        public string? PopisCviku { get; set; }
        public string? TypTreninku { get; set; }
        public string UzivatelId { get; set; }
    }
}
