using BP_TPWA.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BP_TPWA.Models
{
    public class Uzivatel : IdentityUser
    {
        public string Jméno { get; set; }
        public string Příjmení { get; set; }
        public int Věk { get; set; }
        public int Výška { get; set; }
        public int Váha { get; set; }
        public int Úroveň { get; set; }
        public int? TPId { get; set; }

    }
}
