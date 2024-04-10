using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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
        [NotMapped]
        public List<string>? TypyTreninku { get; set; }

        // Sloupec pro ukládání JSON reprezentace seznamu typů tréninků
        [Column("TypTreninku")]
        public string? TypTreninkuSerialized
        {
            get => TypyTreninku != null ? string.Join(",", TypyTreninku) : null;
            set => TypyTreninku = value?.Split(',').ToList();
        }
        public string UzivatelId { get; set; }
    }
}
