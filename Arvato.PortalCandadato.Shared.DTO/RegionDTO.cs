using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvato.PortalCandadato.Shared.DTO
{
    public class RegionDTO
    {

       
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string SedeName { get; set; }

        [Required]
        [StringLength(100)]
        public string RegionName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

      
        public string User { get; set; }
    }
}
