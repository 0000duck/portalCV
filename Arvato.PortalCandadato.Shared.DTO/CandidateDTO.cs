using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvato.PortalCandadato.Shared.DTO
{
    public class CandidateDTO
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Surname { get; set; }

        [Required]
        [StringLength(150)]
        public string RegionsIds { get; set; }

        [Required]
        [StringLength(100)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string PathCV { get; set; }

        [Required]
        [StringLength(100)]
        public string User { get; set; }

        public DateTime TimeIn { get; set; }

        public bool IsDelete { get; set; }

        public DateTime? TimeDelete { get; set; }
        public bool IsRead { get; set; }

        public DateTime? TimeRead { get; set; }
    }
}
