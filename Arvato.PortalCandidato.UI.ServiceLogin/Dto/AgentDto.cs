using System.ComponentModel.DataAnnotations;

namespace ServiceLogin.Dto
{
    public class AgentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonId { get; set; }
        public string Nif { get; set; }
        public int IdRH { get; set; }
        public string Category { get; set; }
        public string UserNT { get; set; }
        public int? AgentSubId { get; set; }
        public int? AgentSubIdBackup { get; set; }
        public int SiteId { get; set; }
        public int SubprojectId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un area")]
        [Display(Name = "Area")]
        public int AreaId { get; set; }

        public int RoleId { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public SubprojectDto Subproject { get; set; }
        public SiteDto Site { get; set; }
        public RoleDto Role { get; set; }

        public AreaDto Area { get; set; }

    }
}
