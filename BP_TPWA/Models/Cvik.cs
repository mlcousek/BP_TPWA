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
        [NotMapped]
        public List<string>? PočtyOpakování { get; set; }

        [Column("PočetOpakování")]
        public string? PočetOpakováníSerialized
        {
            get => PočtyOpakování != null ? string.Join(".", PočtyOpakování) : null;
            set => PočtyOpakování = value?.Split('.').ToList();
        }
        //public string PočetOpakování { get; set; }
        [NotMapped]
        public List<int>? PočtySérií { get; set; }

        [Column("PočetSérií")]
        public string? PočetSériíSerialized
        {
            get => PočtySérií != null ? string.Join(",", PočtySérií) : null;
            set => PočtySérií = value?.Split(',').Select(int.Parse).ToList();
        }
        //public int PočetSérií { get; set; }
        [NotMapped]
        public List<int>? PauzyMeziSériemi { get; set; }

        [Column("PauzaMeziSériemi")]
        public string? PauzaMeziSériemiSerialized
        {
            get => PauzyMeziSériemi != null ? string.Join(",", PauzyMeziSériemi) : null;
            set => PauzyMeziSériemi = value?.Split(',').Select(int.Parse).ToList();
        }
        //public int PauzaMeziSériemi { get; set; }
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
