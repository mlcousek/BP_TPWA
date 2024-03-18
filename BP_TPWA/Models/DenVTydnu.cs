using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BP_TPWA.Models
{
    public class DenVTydnu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DayOfWeek Den { get; set; }
        public Boolean DenTréninku { get; set; }
        public string? TypTreninku { get; set; }



    }
    public static class PomocnikSDaty
    {
        public static string ZjistitJmeno(DayOfWeek dayOfWeek)
        {
            CultureInfo cultureInfo = new CultureInfo("cs-CZ"); // Čeština
            return cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
        }
    }


}
