using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLogin.Dto
{
    public class pdiValidacionDTO
    {
        public int idDominio { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public int personPK { get; set; }

    }
}
