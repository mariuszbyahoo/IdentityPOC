using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityPOC.Models
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string PotwierdzHaslo { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
    }
}
