using System.ComponentModel.DataAnnotations;

namespace Arvato.PortalCandidato.UI.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        //[Required]
        [Display(Name = "Sede")]
        public int Domain { get; set; }

        [Display(Name = "Recuerdame?")]
        public bool RememberMe { get; set; }

        [Display(Name = "Suplantar")]
        public bool Suplantar { get; set; }

        [Display(Name = "Idioma")]
        public string Idioma { get; set; }
    }
}