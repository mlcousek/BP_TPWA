using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        [JsonIgnore]
        [Required]
        [Display(Name = "Dny v týdnu")]
        public List<DenVTydnu> DnyVTydnu { get; set; }

        [ForeignKey("UzivatelID")]
        public Uzivatel User { get; set; }

        [Required]
        public string UzivatelID { get; set; }

        public bool ZkontrolovaneDny {  get; set; }

        public bool UlozenaDataDnu { get; set; }
        public bool AktualniVaha {  get; set; }
        public DateTime DatumPoslednihoUlozeniVahy {  get; set; }


        public TP() {
            DnyVTydnu = new List<DenVTydnu>();
        }

    }
}
