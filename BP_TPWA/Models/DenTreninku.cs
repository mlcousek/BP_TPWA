using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BP_TPWA.Models
{
    public class DenTreninku
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Datum tréninku")]
        public DateTime DatumTreninku { get; set; }
        
        [Required]
        public string TypTreninku { get; set; }

        // Cizí klíč od TP
        public int TPId { get; set; }

        // Navigační vlastnost pro vztah s TP
        [ForeignKey("TPId")]
        public TP TP { get; set; }

        // Seznam cviků pro tento den tréninku (serializovaný jako JSON)
        [NotMapped]
        public List<Cvik> Cviky { get; set; }

        // Sloupec pro ukládání JSON reprezentace seznamu cviků
        [Column("Cviky")]
        public string CvikySerialized
        {
            get => JsonConvert.SerializeObject(Cviky);
            set => Cviky = JsonConvert.DeserializeObject<List<Cvik>>(value);
        }

    }
}
