using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    }
}
