using System.ComponentModel.DataAnnotations;

namespace IdentityPOC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string KodKreskowy { get; set; }
        [Required]
        public string Haslo { get; set; }
    }
}