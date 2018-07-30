using System.ComponentModel.DataAnnotations;

namespace ServiceLogin.Dto
{
    public class AreaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe introducir una Descripción")]
        [MaxLength(100)]
        [Display(Name = "Area")]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
