using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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



        //public void SetDenTréninku(DayOfWeek den, bool trénink)
        //{
        //    var konkrétníDen = DnyVTydnu.FirstOrDefault(d => d.Den == den);
        //    if (konkrétníDen != null)
        //    {
        //        konkrétníDen.DenTréninku = trénink;
        //    }
        //    else
        //    {
        //        throw new Exception("Chyba, špatný den!");
        //    }
        //}

        public TP() {
            DnyVTydnu = new List<DenVTydnu>();
            //{
            //    new DenVTydnu { Den = DayOfWeek.Monday, DenTréninku = false, TypTreninku = "Legday" },
            //    new DenVTydnu { Den = DayOfWeek.Tuesday, DenTréninku = false },
            //    new DenVTydnu { Den = DayOfWeek.Wednesday, DenTréninku = false },
            //    new DenVTydnu { Den = DayOfWeek.Thursday, DenTréninku = false },
            //    new DenVTydnu { Den = DayOfWeek.Friday, DenTréninku = false },
            //    new DenVTydnu { Den = DayOfWeek.Saturday, DenTréninku = false },
            //    new DenVTydnu { Den = DayOfWeek.Sunday, DenTréninku = false }
            //};



        }

    }
}
