using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BP_TPWA.Models
{
    public class TP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Délka { get; set; }
        public string DruhTP { get; set; }
        public string StylTP { get; set; }

        [Required]
        [Display(Name = "Počet tréninků za týden")]
        public int PocetTreninkuZaTyden { get; set; }
       


        [ForeignKey("UzivatelID")]
        public Uzivatel User { get; set; }

        [Required]
        public string UzivatelID { get; set; }

        public TP() {
           
        }

    }
}
